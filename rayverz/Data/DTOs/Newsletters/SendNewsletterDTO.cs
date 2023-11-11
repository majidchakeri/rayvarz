namespace rayverz.Data.DTOs.Newsletters
{
    public class SendNewsletterDTO
    {
        public Guid NewsletterId { get; set; }
        public List<Guid> UserIds { get; set; }
    }
}
