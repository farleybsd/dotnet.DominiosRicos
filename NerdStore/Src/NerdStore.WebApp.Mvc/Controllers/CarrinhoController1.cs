using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Bus;
using NerdStore.Vendas.Application.Commads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class CarrinhoController1 : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediaTrHandler _mediatorHandler;

        public CarrinhoController1(IProdutoAppService produtoAppService, IMediaTrHandler mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id , int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            if(produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(command);

            //DeuCERTO ?

            TempData["Erro"] = "Produto Indisponivel";
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
