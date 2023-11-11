namespace rayverz.Data.Entities
{
    public class Newsletter
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public List<NewsletterUserState> NewsletterUserStates { get; set; }

    }
}
