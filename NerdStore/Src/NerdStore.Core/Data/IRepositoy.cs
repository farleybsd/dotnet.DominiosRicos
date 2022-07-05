using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.Data
{
    public interface IRepositoy<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get;}
    }
}
