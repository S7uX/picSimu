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

        _memory = memory;
    }

    public void Write()
    {
        var payload = GenerateSerialPayload();
        // Makes sure serial port is open before trying to write  
        try
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }

            _serialPort.Write(payload, 0, payload.Length);
            
            if (_serialPort.BytesToRead > 4)
            {
                var data = new byte[5];
                _serialPort.Read(data, 0, 5); // Get Bytes
                uint valueToSet = 0;
                valueToSet = (data[0] & (uint)0b_00001111) << 4; //Get Highbyte of PortA
                valueToSet |= (data[1] & (uint)0b_00001111); //Get Lowbyte of PortA
                _memory.PortA.ExternalValue = valueToSet; //Write PortA
                if (valueToSet.IsBitSet(5))
                {
                    _memory.MCLRPIN = true;
                }
                else
                {
                    _memory.MCLRPIN = false;
                }
                valueToSet = (data[2] & (uint)0b_00001111) << 4; //Get Highbyte of PortA
                valueToSet |= (data[3] & (uint)0b_00001111); //Get Lowbyte of PortA
                _memory.PortB.ExternalValue = valueToSet; //Write PortA
            }
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
        uint trisaReg = _memory.ReadRegister(0x85);
        uint trisbReg = _memory.ReadRegister(0x86);

        // TRISA
        sb.Append("0011");
        sb.Append(trisaReg.IsBitSet(7).ToNumber());
        sb.Append(trisaReg.IsBitSet(6).ToNumber());
        sb.Append(trisaReg.IsBitSet(5).ToNumber());
        sb.Append(trisaReg.IsBitSet(4).ToNumber());
        payload[0] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(trisaReg.IsBitSet(3).ToNumber());
        sb.Append(trisaReg.IsBitSet(2).ToNumber());
        sb.Append(trisaReg.IsBitSet(1).ToNumber());
        sb.Append(trisaReg.IsBitSet(0).ToNumber());
        payload[1] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();

        // port a
        sb.Append("0011");
        sb.Append(portA.ExternalValue.IsBitSet(7).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet(6).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet(5).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet(4).ToNumber());
        payload[2] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(portA.ExternalValue.IsBitSet(3).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet(2).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet(1).ToNumber());
        sb.Append(portA.ExternalValue.IsBitSet(0).ToNumber());
        payload[3] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();

        // TRISB
        sb.Append("0011");
        sb.Append(trisbReg.IsBitSet(7).ToNumber());
        sb.Append(trisbReg.IsBitSet(6).ToNumber());
        sb.Append(trisbReg.IsBitSet(5).ToNumber());
        sb.Append(trisbReg.IsBitSet(4).ToNumber());
        payload[4] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(trisbReg.IsBitSet(3).ToNumber());
        sb.Append(trisbReg.IsBitSet(2).ToNumber());
        sb.Append(trisbReg.IsBitSet(1).ToNumber());
        sb.Append(trisbReg.IsBitSet(0).ToNumber());
        payload[5] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();

        // port b
        sb.Append("0011");
        sb.Append(portB.ExternalValue.IsBitSet(7).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet(6).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet(5).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet(4).ToNumber());
        payload[6] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        sb.Append("0011");
        sb.Append(portB.ExternalValue.IsBitSet(3).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet(2).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet(1).ToNumber());
        sb.Append(portB.ExternalValue.IsBitSet(0).ToNumber());
        payload[7] = Convert.ToByte(sb.ToString(), 2);
        sb.Clear();
        
        sb.Append("00001101");
        payload[8] = Convert.ToByte(sb.ToString(), 2);
        return payload;
    }

    public void Dispose()
    {
        _serialPort.Close();
        _serialPort.Dispose();
    }
}