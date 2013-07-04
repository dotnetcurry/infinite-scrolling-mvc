using InfiniteScrollingOnClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InfiniteScrollingOnClient.Controllers
{
    public class PostServiceController : ApiController
    {
        IPostRepository _repository;

        public PostServiceController(IPostRepository repo)
        {
            _repository = repo;
        }

        /// <summary>
        /// Delete this if you are using an IoC controller
        /// </summary>
        public PostServiceController()
        {
            _repository = new PostRepository();
        }

        [HttpGet]
        public IEnumerable<Post> GetPosts(int id)
        {
            IEnumerable<Post> posts = _repository.PostPage(id, 5);
            return posts;
        }
    }
}
