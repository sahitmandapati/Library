using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly string _csvFilePath;

        public BooksController()
        {
            _csvFilePath = $"{Environment.CurrentDirectory}/Properties/library.csv";
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            var reader = new StreamReader(_csvFilePath);


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line is not null)
                    {
                        var values = line.Split(',');
                        books.Add(new Book
                        {
                            Title = values[0],
                            Author = values[1],
                            YearPublished = Convert.ToInt32(values[2])
                        });
                    }

                }
            

            return books;
        }
    }
}
