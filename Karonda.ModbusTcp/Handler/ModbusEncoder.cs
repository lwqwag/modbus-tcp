using DotNetty.Transport.Channels;
using Karonda.ModbusTcp.Entity;
using System.Threading.Tasks;

namespace Karonda.ModbusTcp.Handler
{
    public class ModbusEncoder : ChannelHandlerAdapter
    {
        public override Task WriteAsync(IChannelHandlerContext context, object message)
        {
            if (message is ModbusFrame frame)
            {
                return context.WriteAndFlushAsync(frame.Encode());
            }

            return context.WriteAsync(message);
        }
    }
}
