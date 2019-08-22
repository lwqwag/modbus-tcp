namespace Karonda.ModbusTcp.Entity.Function.Request
{
    public class WriteSingleCoilRequest : WriteSingleCoil
    {
        public WriteSingleCoilRequest()
            : base()
        {

        }

        public WriteSingleCoilRequest(ushort startingAddress, bool state)
            : base(startingAddress, state)
        {
        }
    }
}
