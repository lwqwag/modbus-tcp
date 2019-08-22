namespace Karonda.ModbusTcp.Entity.Function.Response
{
    public class ReadHoldingRegistersResponse : ReadRegistersResponse
    {
        public ReadHoldingRegistersResponse()
            : base((short)ModbusCommand.ReadHoldingRegisters)
        {

        }

        public ReadHoldingRegistersResponse(ushort[] registers)
            : base((short)ModbusCommand.ReadHoldingRegisters, registers)
        {
        }
    }
}
