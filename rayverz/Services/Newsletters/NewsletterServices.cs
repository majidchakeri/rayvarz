using AutoMapper;
using rayverz.Data.Contexts;
using rayverz.Data.DTOs.Newsletters;
using rayverz.Data.Entities;
using rayverz.Services.Messages;
using rayverz.Services.Newsletters;

namespace rayverz.Services.Newsletters
{
    public class NewsletterServices : INewsletterServices

    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IMessageServices _messageServices;

        public NewsletterServices(DatabaseContext databaseContext, IMapper mapper, IMessageServices messageServices)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _messageServices = messageServices;
        }

        public async Task<Guid> Create(NewsletterAddDTO newsletter)
        {
            var ne = _mapper.Map<Newsletter>(newsletter);
            ne.Date = DateTime.Now;

            await _databaseContext.Newsletters.AddAsync(ne);
            await _databaseContext.SaveChangesAsync();
            
            return ne.Id;
        }

        public async Task<NewsletterGetDTO?> Read(Guid id)
        {
            var readEn = await _databaseContext.Newsletters.FindAsync(id);
            if (readEn == null)
            {
                return null;
            }

            return _mapper.Map<NewsletterGetDTO> (readEn);
        }

        public async Task SendNewsletter(Guid newsletterId, List<Guid> userIds)
        {
            //با توجه به حجم درخواست ها باید در این مرحله دستور استارت شدن یک پراسس در بک گراند صادر شود.
            // به این دلیل که اگر حجم دعوت نامه ارسالی زیاد باشد یا فرآیند طولانی شود تایم اوت در یافت میکنیم.
            // همچنین می توان بجای فراخوانی این متد توسط کنترلر آن را در یک کرون جاب فراخوانی کرد.

            foreach (var userId in userIds)
            {
                await _databaseContext.NewletterState.AddAsync(
                    new NewsletterUserState {
                        NewsletterId = newsletterId,
                        UserId = userId,
                        IsSent = _messageServices.Send(newsletterId, userId)
                        });

            }
            _databaseContext.SaveChanges();
        }
    }
}
