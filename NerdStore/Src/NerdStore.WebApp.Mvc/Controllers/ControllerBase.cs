
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Bus;
using NerdStore.Core.Messages.CommomMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediaTrHandler _mediaTrHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications,
                                 IMediaTrHandler mediaTrHandler)
        {
            _notifications = (DomainNotificationHandler) notifications;
            _mediaTrHandler = mediaTrHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected void NotificarErro(string codigo,string mensagem)
        {
            _mediaTrHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

        protected IEnumerable<string> obterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }
    }
}
