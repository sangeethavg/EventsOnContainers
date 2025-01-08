using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController (EventContext context, IConfiguration config)
        { 
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async  Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0,
        [FromQuery]int pageSize = 6
            )
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items = await _context.Events
                .OrderBy(c => c.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }
        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Items(
            [FromQuery] int? eventTypeId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.Events;
            if (eventTypeId.HasValue)
            {
                query = query.Where(c => c.EventTypeId
                == eventTypeId.Value);
            }

            var itemsCount = query.LongCountAsync();
            var items = await query
                .OrderBy(x => x.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }
        private List<Event> ChangePictureUrl(List<Event> items)
        {
            foreach (var item in items)
            {
                item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalBaseUrl"]);
            }
            return items;
        }
    }
}
