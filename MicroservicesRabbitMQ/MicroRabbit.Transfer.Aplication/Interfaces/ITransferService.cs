using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Aplication.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
