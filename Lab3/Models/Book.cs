using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Lab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        //Danh sách các cuốn sách
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Image/products/b1.jpg",
                    Price = 5000,
                    Summary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Image/products/b2.jpg",
                    Price = 7000,
                    Summary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 3,
                    Title = "Thám tử lừng danh Conan",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Image/products/b3.jpg",
                    Price = 10000,
                    Summary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 4,
                    Title = "Đường xưa mây trắng",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/Image/products/b4.jpg",
                    Price = 8000,
                    Summary = "",
                    TotalPage = 250
                }
            };
            return books;
        }
        //Chi tiết các cuốn sách theo Id
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        //SelectListItem Authour
        public List<SelectListItem> author { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1",Text="Nam Cao"},
            new SelectListItem {Value="2", Text = "Ngô Tất Tố"},
            new SelectListItem {Value="3", Text = "Aoyama"},
            new SelectListItem {Value="4", Text = "Thích Nhất Hạnh"}
        };
        public List<SelectListItem> genre { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="1",Text="Truyện tranh"},
            new SelectListItem {Value="2", Text = "Văn học"},
            new SelectListItem {Value="3", Text = "Truyện cười"},
            new SelectListItem {Value="4", Text = "Phật học"}
        };
    }
}
