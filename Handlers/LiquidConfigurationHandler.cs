using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Scripting.Liquid.Messages;
using Fluid;
using MediatR;

namespace Coffee.Handlers
{
    public class LiquidConfigurationHandler : INotificationHandler<EvaluatingLiquidExpression>
    {
        public Task Handle(EvaluatingLiquidExpression notification, CancellationToken cancellationToken)
        {
            notification.TemplateContext.Options.MemberAccessStrategy = new UnsafeMemberAccessStrategy();
            notification.TemplateContext.Options.MemberAccessStrategy.Register<CoffeeType>();

            notification.TemplateContext.Options.MemberAccessStrategy.Register<List<CoffeeType>>();

            return Task.CompletedTask;
        }
    }
}
