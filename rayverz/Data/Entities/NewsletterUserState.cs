namespace rayverz.Data.Entities
{
    public class NewsletterUserState
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public bool IsSent { get; set; }
        public Newsletter Newsletter { get; set; }
        public Guid NewsletterId { get; set; }
    }
}
