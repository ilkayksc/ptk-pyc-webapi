using System;

namespace PycApi.Data
{
    public class Book
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
    }
}
