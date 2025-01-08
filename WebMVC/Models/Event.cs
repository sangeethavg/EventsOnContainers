namespace WebMVC.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public decimal Ticket { get; set; }
        public string PictureUrl { get; set; }
        public int EventTypeId { get; set; }

        public string EventType { get; set; }
    }
}
