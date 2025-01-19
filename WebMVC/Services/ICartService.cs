﻿using WebMVC.Models;
using WebMVC.Models.CartModels;
using WebMVC.Models.OrderModels;

namespace WebMVC.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart(ApplicationUser user);
        Task AddItemToCart(ApplicationUser user, CartItem product);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities);
        Order MapCartToOrder(Cart cart);
        Task ClearCart(ApplicationUser user);
    }
}
