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
        public IEnumerable<Book> GetAllBooks([FromQuery] Genre? Genre = null)
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
                            Genre = (Genre)Enum.Parse(typeof(Genre), values[2]),
                            YearPublished = Convert.ToInt32(values[3])
                        });
                    }

                }

            if (Genre != null)
            {
                return books.Where(item => item.Genre == Genre);
            }
            else
            {
                return books;
            }
        }
    }
}
