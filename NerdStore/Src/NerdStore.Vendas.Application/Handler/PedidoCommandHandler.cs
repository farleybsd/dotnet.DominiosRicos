using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Application.Commads;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using NerdStore.Core.Bus;
using NerdStore.Core.Messages.CommomMessages.Notifications;

namespace NerdStore.Vendas.Application.Handler
{
    public class PedidoCommandHandler :
        IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMediaTrHandler _mediaTrHandler;
        public PedidoCommandHandler(IPedidoRepository pedidoRepository,
                                    IMediaTrHandler mediaTrHandler)
        {
            _pedidoRepository = pedidoRepository;
            _mediaTrHandler = mediaTrHandler;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClienteId);
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

            if (pedido == null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
                pedido.AdicionarItem(pedidoItem);
                _pedidoRepository.Adicionar(pedido);
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemExistente)
                {
                    _pedidoRepository.AtualizarItem(pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
                }
                else
                {
                    _pedidoRepository.AdicionarItem(pedidoItem);
                }
            }


            return  await _pedidoRepository.UnitOfWork.Commit();
        }



        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediaTrHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));

            }

            return false;
        }
    }
}
