using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommomMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Bus
{
    public class MediaTrHandler : IMediaTrHandler
    {
        private readonly IMediator _mediator;

        public MediaTrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando); //request
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento); // notificacao
        }

        public async  Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }
}
