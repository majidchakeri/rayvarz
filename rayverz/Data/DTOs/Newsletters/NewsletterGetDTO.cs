namespace rayverz.Data.DTOs.Newsletters
{
    public class NewsletterGetDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
