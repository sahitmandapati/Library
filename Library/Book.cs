namespace Library
{
    public class Book
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public Genre Genre { get; set; }
        public int YearPublished { get; set; }
        

    }

    public enum Genre
    {
        Fiction,
        Satire,
        Thriller,
        Philosophy,
        Scifi
    }
}
