using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commads
{
    public class RemoverItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public RemoverItemPedidoCommand(Guid clienteId, Guid produtoId)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            //PedidoId = pedidoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverrItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverrItemPedidoValidation : AbstractValidator<RemoverItemPedidoCommand>
    {
        public RemoverrItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.PedidoId)
               .NotEqual(Guid.Empty)
               .WithMessage("Id do pedido inválido");

        }
    }
}
