using BooksManager.Interfaces;
using BooksManager.Models.DTOs;
using BooksManager.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.Controllers
{
    public class BooksController : Controller
    {
        public IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IActionResult> BooksDetails()
        {
            try
            {
                var books = await _booksRepository.getAllSortListBooksAPI();
                var booksWithAuthorAndTitle = await _booksRepository.getAllSortListBooksAPIWithAuthorAndTitle();
                var totalPrice = await _booksRepository.getTotalPriceBooksAPI();
                var booksFromProcedure = await _booksRepository.getAllSortListBooksProcedure();
                var booksFromProcedureWithAuthorAndTitle = await _booksRepository.getAllSortListBooksProcedureWithAuthorAndTitle();


                var viewModel = new BooksViewModel
                {
                    books = books,
                    booksWithAuthorAndTitle = booksWithAuthorAndTitle,
                    totalPrice = totalPrice,
                    booksFromProcedure = booksFromProcedure,
                    booksFromProcedureWithAuthorAndTitle = booksFromProcedureWithAuthorAndTitle
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                BooksViewModel viewModel = new BooksViewModel();
                ViewBag.ErrorMessage = "An error occurred while fetching book details. Please try again later.";
                return View(viewModel);
            }

        }

    }
}
