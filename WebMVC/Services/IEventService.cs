using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventService
    {
        Task<IEnumerable<SelectListItem>> GetTypesAsync();

        Task <EventItems?> GetEventsAsync(int page, int Size, int? Type);
    }
}
