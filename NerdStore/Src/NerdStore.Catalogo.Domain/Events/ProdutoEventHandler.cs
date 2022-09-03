using MediatR;
using NerdStore.Core.Bus;
using NerdStore.Core.Messages.CommomMessages.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NerdStore.Core.Messages.CommomMessages.IntegrationEvents.PedidoIniciaoEvent;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : 
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
         INotificationHandler<PedidoIniciaoEvent> // Evento de Pagamento Integracao entre Contexto
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediaTrHandler _mediatorHandler;
        public ProdutoEventHandler(IProdutoRepository produtoRepository,
                                    IEstoqueService estoqueService, 
                                    IMediaTrHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent messagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(messagem.AggregateId);

            //TODO: ENVIAR EMAIL PARA FAZER PEDIDO DE MAIS PRODUTOS.
        }

        public async Task Handle(PedidoIniciaoEvent message, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutoPedido);

            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
            }
        }
    }
}
