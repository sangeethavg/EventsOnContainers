﻿namespace WebMVC.Models.CartModels
{
    public class CartItem
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal OldUnitPrice { get; set; }
    }
}
