using rayverz.Data.Entities;

namespace rayverz.Services.Messages
{
    public interface IMessageServices
    {
        bool Send(Guid newsletter, Guid userId);
    }
}
