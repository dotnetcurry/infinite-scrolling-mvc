using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfiniteScrollingOnClient.Models;

namespace InfiniteScrollingOnClient.Controllers
{   
    public class PostController : Controller
    {
		private readonly IPostRepository postRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PostController() : this(new PostRepository())
        {
        }

        public PostController(IPostRepository postRepository)
        {
			this.postRepository = postRepository;
        }

        //
        // GET: /Post/

        public ViewResult Index()
        {
            return View(postRepository.All);
        }

        //
        // GET: /Post/Details/5

        public ViewResult Details(int id)
        {
            return View(postRepository.Find(id));
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid) {
                postRepository.InsertOrUpdate(post);
                postRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(postRepository.Find(id));
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid) {
                postRepository.InsertOrUpdate(post);
                postRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(postRepository.Find(id));
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            postRepository.Delete(id);
            postRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                postRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

