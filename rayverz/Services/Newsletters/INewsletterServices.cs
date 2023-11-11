using rayverz.Data.DTOs.Newsletters;

namespace rayverz.Services.Newsletters
{
    public interface INewsletterServices
    {
        Task<Guid> Create(NewsletterAddDTO newsletter);
        Task<NewsletterGetDTO?>  Read(Guid id);
        Task SendNewsletter(Guid newsletterId, List<Guid> userIds);
    }
}
