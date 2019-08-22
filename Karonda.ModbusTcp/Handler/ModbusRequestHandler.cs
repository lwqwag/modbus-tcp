using DotNetty.Transport.Channels;
using Karonda.ModbusTcp.Entity;

namespace Karonda.ModbusTcp.Handler
{
    public class ModbusRequestHandler : SimpleChannelInboundHandler<ModbusFrame>
    {
        private ModbusResponseService responseService;
        public ModbusRequestHandler(ModbusResponseService responseService)
        {
            this.responseService = responseService;
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, ModbusFrame msg)
        {
            var function = msg.Function;
            var  response = responseService.Execute(function);

            var header = msg.Header;
            var frame = new ModbusFrame(header, response);

            ctx.WriteAndFlushAsync(frame);
        }
    }
}
