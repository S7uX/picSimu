using System.IO.Ports;
using System.Text;

namespace picSimu.Simulation;

public class SerialHandler : IDisposable
{
    private SerialPort _serialPort;
    private Memory _memory;

    public SerialHandler(string port, Memory memory)
    {
        _serialPort = new SerialPort(port, 4800, Parity.None, 8, StopBits.One);
        _serialPort.Handshake = Handshake.None;
        _serialPort.DataReceived += sp_DataReceived;
        _serialPort.Open();
        
        _memory = memory;
    }

    private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        //Thread.Sleep(100);
        //string data = _serialPort.ReadLine();  
        //TODO
        /*var data = new byte[5];
        Console.WriteLine("Start Read");
        _serialPort.Read(data, 0, data.Length);
        _serialPort.DiscardInBuffer();
        Console.WriteLine("Done Read");
        var sb = new StringBuilder();
        sb.Append("0000");
        sb.Append(Convert.ToString(data[1], 2).PadLeft(8, '0').Substring(4, 4));
        _memory.WriteRegister(0x05, Convert.ToUInt32(sb.ToString(), 2));
        sb.Clear();
        sb.Append(Convert.ToString(data[2], 2).PadLeft(8, '0').Substring(4, 4));
        sb.Append(Convert.ToString(data[3], 2).PadLeft(8, '0').Substring(4, 4));
        _memory.WriteRegister(0x06, Convert.ToUInt32(sb.ToString(), 2));
        sb.Clear();*/
    }

    public void Write()
    {
        byte[] payload = GenerateSerialPayload();
        // Makes sure serial port is open before trying to write  
        try
        {
            _serialPort.Write(payload, 0, payload.Length);
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
            //if (_serialPort.BytesToRead < 4)
            //{
            //    var data = new byte[5];
            //_serialPort.Read(data, 0, 5);
            //var text = _serialPort.ReadExisting();
            //}
            /*if (text.StartsWith("2"))
            {
                _memory.WriteRegister(0x05, _memory.ReadRegister(0x05).SetBitTo0(4));
            }
            else if (text.StartsWith("3"))
            {
                _memory.WriteRegister(0x05, _memory.ReadRegister(0x05).SetBitTo1(4));
            }*/
        }
        catch (Exception ex)
        {
            //("Error opening/writing to serial port :: " + ex.Message, "Error!");
        }
    }

    private byte[] GenerateSerialPayload()
    {
        var payload = new byte[9];
        StringBuilder sb = new StringBuilder();
        Port portA = _memory.PortA;
        Port portB = _memory.PortB;
        uint trisaReg = _memory.ReadRegister(5);
        uint trisbReg = _memory.ReadRegister(6);
        
        sb.Append("0011");
        // port a
        sb.Append(portA.ExternalValue.IsBitSet(7).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet( 6).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet( 5).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet( 4).ToNumber());
        payload[0] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(portA.ExternalValue.IsBitSet( 3).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet( 2).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet( 1).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet( 0).ToNumber());
        payload[1] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(trisaReg.IsBitSet(7).ToNumber());
        sb.Append(trisaReg.IsBitSet(6).ToNumber());
        sb.Append(trisaReg.IsBitSet(5).ToNumber());
        sb.Append(trisaReg.IsBitSet(4).ToNumber());
        payload[2] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(trisaReg.IsBitSet(3).ToNumber());
        sb.Append(trisaReg.IsBitSet(2).ToNumber());
        sb.Append(trisaReg.IsBitSet(1).ToNumber());
        sb.Append(trisaReg.IsBitSet(0).ToNumber());
        payload[3] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        // port b
        sb.Append("0011");
        sb.Append(portB.ExternalValue.IsBitSet( 7).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet( 6).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet( 5).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet( 4).ToNumber());
        payload[4] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(portB.ExternalValue.IsBitSet( 3).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet( 2).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet( 1).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet( 0).ToNumber());
        payload[5] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        // TRISB
        sb.Append(trisbReg.IsBitSet(7).ToNumber());
        sb.Append(trisbReg.IsBitSet(6).ToNumber());
        sb.Append(trisbReg.IsBitSet(5).ToNumber());
        sb.Append(trisbReg.IsBitSet(4).ToNumber());
        payload[6] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(trisbReg.IsBitSet(3).ToNumber());
        sb.Append(trisbReg.IsBitSet(2).ToNumber());
        sb.Append(trisbReg.IsBitSet(1).ToNumber());
        sb.Append(trisbReg.IsBitSet(0).ToNumber());
        payload[7] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("00001101");
        payload[0] = Convert.ToByte(sb.ToString(), 2);
        return payload;
    }

    public void Dispose()
    {
        _serialPort.Close();
        _serialPort.Dispose();
    }
}