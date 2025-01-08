
namespace WebMVC.Infrastructer
{
    public class APIPaths
    {
        public static class Event
        {
            public static string GetAllTypes(string baseUrl)
            {
                return $"{baseUrl}/eventtypes";
            }

            public static string GetAllEvent(string baseUrl, int page, int size, int? type)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (type.HasValue)
                {
                    filterQs = $"eventTypes={type.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUrl}/items?pageIndex={page}&pageSize={size}";
                }
                else
                {
                    preUri = $"{baseUrl}/items/filter?pageIndex={page}&pageSize={size}&{filterQs}";
                }
                return preUri;
            }
        }
    }
}
