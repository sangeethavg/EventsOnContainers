
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
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
        public static class Auth
        {
            public static string Register(string baseUri)
            {
                return $"{baseUri}/register";
            }
            public static string Login(string baseUri)
            {
                return $"{baseUri}/login";
            }
            public static string AssignRole(string baseUri)
            {
                return $"{baseUri}/AssignRole";
            }
        }
        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
