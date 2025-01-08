namespace WebMVC.Models
{
    public class EventItems
    {
        public int Pageindex { get; set; }
    public int Pagesize { get; set; }

      public long Pagecount { get; set; }
      public IEnumerable<Event> Data { get; set; }
}
}
