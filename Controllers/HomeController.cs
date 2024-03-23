using Microsoft.AspNetCore.Mvc;
using Mission11_Yee.Models;
using System.Diagnostics;
using Mission11_Yee.ViewModels;

namespace Mission11_Yee.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 10; // Set the number of items per page
            var books = _repo.Books; //Var for all books

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page, //page user is on
                ItemsPerPage = pageSize, //How many items per page
                TotalItems = books.Count() //Number of books
            };

            //pagination logic
            var booksListViewModel = new BooksListViewModel
            {
                Books = books
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),
                PagingInfo = pagingInfo
            };

            return View(booksListViewModel);
        }
    }
}