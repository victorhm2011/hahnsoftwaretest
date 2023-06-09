﻿using HahnTest.Domain.Entities;
using HahnTest.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System;

namespace HahnTest.Presentation.DTOs
{
    public class BookDto
    {
        public string Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Isbn { get; set; }

        public BookDto(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Price = book.Price;
            PublishDate = book.PublishDate;
        }

        public Book ToEntity()
        {
            return new Book
            {
                Id = Id,
                Title = Title,
                Author = Author,
                Price = Price,
                PublishDate = PublishDate,
            };
        }
    }
}
