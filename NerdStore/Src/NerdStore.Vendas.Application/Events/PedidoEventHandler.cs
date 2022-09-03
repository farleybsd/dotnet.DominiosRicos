using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NerdStore.Core.Messages.CommomMessages.IntegrationEvents.PedidoIniciaoEvent;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRascunhoIniciadoEvent>,
                                      INotificationHandler<PedidoAtualizadoEvent>,
                                      INotificationHandler<PedidoItemAdicionadoEvent>,
                                      INotificationHandler<PedidoEstoqueConfirmadoEvent>,
                                      INotificationHandler<PedidoEstoqueRejeitadoEvent>
    {
    {
    {
        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoEstoqueConfirmadoEvent notification, CancellationToken cancellationToken)
        {
            //Iniciar o Pagamento
            return Task.CompletedTask;
        }

        public Task Handle(PedidoEstoqueRejeitadoEvent notification, CancellationToken cancellationToken)
        {
            // Cancelar o processamento do pedido retornar erro para o cliente
            return Task.CompletedTask;
        }

        Task INotificationHandler<PedidoRascunhoIniciadoEvent>.Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
