using System;

namespace NerdStore.Core.Messages.CommomMessages.IntegrationEvents
{
    public partial class PedidoIniciaoEvent
    {
        public class PedidoEstoqueRejeitadoEvent : IntegrationEvents
        {
            public PedidoEstoqueRejeitadoEvent(Guid pedidoId, Guid clienteId)
            {
                PedidoId = pedidoId;
                ClienteId = clienteId;
            }

            public Guid PedidoId { get; private set; }
            public Guid ClienteId { get; private set; }
           
        }
    }
}
