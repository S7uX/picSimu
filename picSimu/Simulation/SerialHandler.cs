using System.IO.Ports;
using System.Text;

namespace picSimu.Simulation;

public class SerialHandler
{
    private SerialPort _serialPort;
    private Memory _memory;

    public SerialHandler(string port, Memory memory)
    {
        _serialPort = new SerialPort(port, 4800, Parity.None, 8, StopBits.One);
        _serialPort.Handshake = Handshake.None;
        _serialPort.DataReceived +=  sp_DataReceived;
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

    public void Write(byte[] payload)
    {
        // Makes sure serial port is open before trying to write  
        try
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }

            _serialPort.Write(payload, 0, payload.Length);
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
            _serialPort.Close();
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
}