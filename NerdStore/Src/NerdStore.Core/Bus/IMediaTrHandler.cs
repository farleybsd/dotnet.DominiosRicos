using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerdStore.Core.Bus
{
    public interface IMediaTrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
