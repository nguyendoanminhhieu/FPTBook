using FPTBook.Data;
using FPTBook.Models;
using FPTBook.Models.ViewModels;
using FPTBook.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FPTBook.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.BookRepository.GetAll().ToList();
            return View(books);
        }
        public IActionResult CreateUpdate(BookVM bookVM)
        {
            BookVM bookVM = new BookVM();
            {
                Categories = _unitOfWork.CategoryRepository.GetAll().Select(c=>new SelectListItem 
                { 
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Book = new Book()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(bookVM);
            }
            else
            {
                //Update
                bookVM.Book = _unitOfWork.BookRepository.Get(b => b.Id == id);
                return View(bookVM);
            }

        }
        [HttpPost]
        public IActionResult CreateUpdate(Book book)
        {

            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    _unitOfWork.BookRepository.Add(book);
                    TempData["success"] = "Book Created successfully";
                }
                else
                {
                    _unitOfWork.BookRepository.Update(book);
                    TempData["success"] = "Book Updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? book = _unitOfWork.BookRepository.Get(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _unitOfWork.BookRepository.Delete(book);
            _unitOfWork.Save();
            TempData["success"] = "Book Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
