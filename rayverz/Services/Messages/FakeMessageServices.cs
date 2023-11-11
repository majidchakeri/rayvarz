using rayverz.Data.Entities;

namespace rayverz.Services.Messages
{
    public class FakeMessageServices : IMessageServices
    {
        public bool Send(Guid newsletter, Guid userId)
        {
            try
            {
                Console.WriteLine($"message sent to {userId}");
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
