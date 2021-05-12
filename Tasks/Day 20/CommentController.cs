using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Controllers
{
    public class CommentController : Controller
    {
        static List<Comment> comments = new List<Comment>()
        {
            new Comment(){Id = 101,PostText="Checkstatus of movie on May 12 th",CommentText="Movie released"},

            new Comment(){Id = 102,PostText="wash hands with soap",CommentText="stay safe"},

            new Comment(){Id = 103,PostText="new arrivals! pizza and sandwich",CommentText="Tasty"},

        };
        public IActionResult Index()
        {
            return View(comments);
        }
     
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            comments.Add(comment);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int idx = comments.FindIndex(c => c.Id == id);
            return View(comments[idx]);
        }
        [HttpPost]
        public IActionResult Edit(int id, Comment comment)
        {
            int idx = comments.FindIndex(c => c.Id == id);
            comments[idx].PostText = comment.PostText;
            comments[idx].CommentText = comment.CommentText;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {

            int idx = comments.FindIndex(c => c.Id == id);
            return View(comments[idx]);

        }
        [HttpPost]

        public IActionResult Delete(int id, Post post)
        {
            int idx = comments.FindIndex(c => c.Id == id);
            comments.RemoveAt(idx);
            return RedirectToAction("Index");
        }

    }
}
