using System.Collections;

namespace Karonda.ModbusTcp.Entity.Function.Response
{
    public class ReadDiscreteInputsResponse : ReadCoilsInputsResponse
    {
        public BitArray Inputs
        {
            get
            {
                return CoilsOrInputs;
            }
        }

        public ReadDiscreteInputsResponse()
            : base((short)ModbusCommand.ReadDiscreteInputs)
        {

        }

        public ReadDiscreteInputsResponse(BitArray coils)
            : base((short)ModbusCommand.ReadDiscreteInputs, coils)
        {
        }
    }
}
