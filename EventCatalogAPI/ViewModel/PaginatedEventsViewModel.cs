using EventCatalogAPI.Domain;

namespace EventCatalogAPI.ViewModel
{
    public class PaginatedEventsViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<Event> Data { get; set; }
    }
}
