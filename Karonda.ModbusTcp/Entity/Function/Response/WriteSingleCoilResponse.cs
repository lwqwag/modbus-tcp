namespace Karonda.ModbusTcp.Entity.Function.Response
{
    public class WriteSingleCoilResponse : WriteSingleCoil
    {
        public WriteSingleCoilResponse()
            : base()
        {

        }

        public WriteSingleCoilResponse(ushort startingAddress, bool state)
            : base(startingAddress, state)
        {
        }
    }
}
