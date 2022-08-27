using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commads
{
    public class AplicarVoucherPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public string CodigoVoucher { get; private set; }
        public AplicarVoucherPedidoCommand(Guid clienteId, string codigoVoucher)
        {
            ClienteId = clienteId;
            //PedidoId = pedidoId;
            CodigoVoucher = codigoVoucher;
        }

        public override bool EhValido()
        {
            ValidationResult = new AAplicarVoucherPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AAplicarVoucherPedidoValidation : AbstractValidator<AplicarVoucherPedidoCommand>
    {
        public AAplicarVoucherPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.PedidoId)
               .NotEqual(Guid.Empty)
               .WithMessage("Id do pedido inválido");

            RuleFor( c => c.CodigoVoucher)
                .NotEmpty()
                .WithMessage("O còdigo do Voucher não pode ser vazio!");
        }
    }
}
