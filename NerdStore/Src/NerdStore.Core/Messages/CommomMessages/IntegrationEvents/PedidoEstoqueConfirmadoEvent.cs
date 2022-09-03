using NerdStore.Core.DomainObjects.Dto;
using System;

namespace NerdStore.Core.Messages.CommomMessages.IntegrationEvents
{
    public partial class PedidoIniciaoEvent
    {
        public class PedidoEstoqueConfirmadoEvent : IntegrationEvents
        {
            public PedidoEstoqueConfirmadoEvent(Guid pedidoId, Guid clienteId, decimal total,
                                                ListaProdutoPedido produtoPedido, string nomeCartao, 
                                                string numeroCartao, string expiracaoCartao, string cvvCartao)
            {
                PedidoId = pedidoId;
                ClienteId = clienteId;
                Total = total;
                ProdutoPedido = produtoPedido;
                NomeCartao = nomeCartao;
                NumeroCartao = numeroCartao;
                ExpiracaoCartao = expiracaoCartao;
                CvvCartao = cvvCartao;
            }

            public Guid PedidoId { get; private set; }
            public Guid ClienteId { get; private set; }
            public decimal Total { get; private set; }
            public ListaProdutoPedido ProdutoPedido { get; private set; } //DTO ENTRE CONTEXTO
            public string NomeCartao { get; private set; }
            public string NumeroCartao { get; private set; }
            public string ExpiracaoCartao { get; private set; }
            public string CvvCartao { get; private set; }
        }
    }
}
