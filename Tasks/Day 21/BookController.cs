using LearningMVCProject.Models;
using LearningMVCProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVCProject.Controllers
{
    public class BookController : Controller
    {
        private IRepo<Book> _repo;
        private ILogger<BookController> _logger;

        public BookController(IRepo<Book> repo, ILogger<BookController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {

            List<Book> books = _repo.GetAll().ToList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            Book book = _repo.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Details(Book book)
        {
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Book book)
        {
            _repo.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Book book = _repo.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            _repo.Update(id, book);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Book b = _repo.Get(id);
            return View(b);

        }
        [HttpPost]
        public IActionResult Delete(Book b)
        {
            _repo.Delete(b);
            return RedirectToAction("Index");
        }
    }
}