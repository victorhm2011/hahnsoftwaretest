﻿namespace HahnTest.Domain.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
