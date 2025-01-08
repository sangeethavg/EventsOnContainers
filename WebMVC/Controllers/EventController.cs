using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _Service;
        public EventController(IEventService service)
        {
            _Service = service;
        }
        public async Task<IActionResult> Index(int? page, int? typeFilterApplied)

        {
            var itemsOnPage = 3;
            var Event = await _Service.GetEventsAsync(page ?? 0, itemsOnPage, typeFilterApplied);
            var vm = new EventIndexViewModel
            {
                Types = await _Service.GetTypesAsync(),
                Events = Event.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = Event.Pageindex,
                    TotalItems = Event.Pagecount,
                    ItemsPerPage = Event.Pagesize,
                    TotalPages = (int)Math.Ceiling((decimal)Event.Pagecount / itemsOnPage),
                },
                TypeFilterApplied = typeFilterApplied,

            };

            return View(vm);
        }
    }
}