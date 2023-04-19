﻿namespace Library
{
    public class Book
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int YearPublished { get; set; }
        

    }
}
