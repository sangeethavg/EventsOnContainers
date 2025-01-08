using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebMVC.Infrastructer;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _httpClient;
        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["EventUrl"]}/api/event";
            _httpClient = client;
        }

        public async Task<EventItems?> GetEventsAsync(int page, int Size, int? Type)
        {
            var eventTypesUri = APIPaths.Event.GetAllEvent(_baseUrl, page, Size, Type);
            var dataString = await _httpClient.GetStringAsync(eventTypesUri);
            Console.WriteLine(dataString);
            return JsonConvert.DeserializeObject<EventItems?>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = APIPaths.Event.GetAllTypes(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(typeUri);
            var items = new List<SelectListItem>();
            var initialItem = new SelectListItem
            {
                Value = null,
                Text = "All",
                Selected = true
            };
            items.Add(initialItem);
        
            var types = JArray.Parse(dataString);
            foreach (var item in types)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("type")
                });
            }
            return items;

        }
    }
}