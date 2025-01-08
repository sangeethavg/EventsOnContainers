using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace EventCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetEventTypes());
                context.SaveChanges();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange(GetEvents());
                context.SaveChanges();
            }
        }

        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event() {
                Name = "The Halloween Party",Location = "200 Talmadge Avenue",Time = "Saturday 26, october 9:30PM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1",EventTypeId=2 },
                new Event() {
                    Name = "Great Food Expo",Location = "New Jersey Expo Center",Time = "Sunday 27, october 11:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2",EventTypeId=5 },
                 new Event() {
                    Name = "Benjamin's 2000 Reload",Location = "Crossroads",Time = "Friday 20, october 7:30PM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3",EventTypeId=1},
                  new Event() {
                    Name = "The Healing Power of Sound",Location = "Soma Vayu Gardening",Time = "Wednesday 16, october 11:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4",EventTypeId=3 },
                   new Event() {
                    Name = "Project Management Basics",Location = "Edison, New Jersey",Time = "Thursday 24, october 9:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",EventTypeId=3 },
                   new Event() {
                    Name = "Art Meetup",Location = "Edison, New Jersey",Time = "Thursday 24, october 9:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",EventTypeId=4 },
                   new Event() {
                    Name = "New Year, New Wealth",Location = "Edison, New Jersey",Time = "Thursday 24, october 9:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",EventTypeId=5 },
                   new Event() {
                    Name = "Full moon sound healing",Location = "Edison, New Jersey",Time = "Thursday 24, october 9:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",EventTypeId=3 },
                   new Event() {
                    Name = "Pickle Ball, Deals and Dinks",Location = "Edison, New Jersey",Time = "Thursday 24, october 9:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",EventTypeId=3 },
                   new Event() {
                    Name = "New Jersey 2025 Soccer Awards",Location = "Edison, New Jersey",Time = "Thursday 24, october 9:30AM",Duration = "3hours",Ticket=20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5",EventTypeId=3 }
            };
        }

        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>()
            {
                new EventType {Type = "Music" },
                new EventType {Type = "Comedy" },
                new EventType {Type = "Performimg arts" },
                new EventType {Type = "Educational" },
                new EventType {Type = "Food & Drinks" }
            };
        }
    }
}