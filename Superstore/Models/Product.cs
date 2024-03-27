﻿namespace Superstore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
