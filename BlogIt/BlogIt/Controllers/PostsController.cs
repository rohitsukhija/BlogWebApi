using BlogIt.Filters;
using BlogIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BlogIt.Controllers
{
    [BasicAuthentication]
    public class PostsController : ApiController
    {
        // storing in thread principle so that on further extension to this app, we can make access to edit/update/delete to owner only.
        //static string userName = Thread.CurrentPrincipal.Identity.Name;

        DatabaseContext db = new DatabaseContext();

        /// <summary>
        /// Getting all the list of Posts
        /// </summary>
        /// <returns>List of Posts</returns>
        //GET - api/posts
        public IEnumerable<Posts> Get()
        {
            try
            {
                return db.Posts.ToList();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: {ex.Message} - {ex.ToString()}");
                return null;
            }

        }

        /// <summary>
        /// Getting a single Posts
        /// </summary>
        /// <param name="id">Id of the Posts</param>
        /// <returns>Post object</returns>
        //GET - api/posts/{id}
        public Posts Get(string id)
        {
            try
            {
                return db.Posts.FirstOrDefault(p => p.id == new Guid(id));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: {ex.Message} - {ex.ToString()}");
                return null;
            }
        }

        /// <summary>
        /// Storing a new Post
        /// </summary>
        /// <param name="post">Post object</param>
        /// <returns>HttpResponseMessage</returns>
        //POST - api/posts
        [HttpPost]
        public HttpResponseMessage AddPost(Posts post)
        {
            try
            {
                post.id = Guid.NewGuid();
                db.Posts.Add(post);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: {ex.Message} - {ex.ToString()}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Editing a Post
        /// </summary>
        /// <param name="Post">Post object that needs to be updated</param>
        /// <returns>HttpResponseMessage</returns>
        //PUT - api/posts
        [HttpPut]
        public HttpResponseMessage EditPost(Posts post)
        {
            try
            {
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: {ex.Message} - {ex.ToString()}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deleting a Post
        /// </summary>
        /// <param name="Id">Id of the post that needs to be updated</param>
        /// <returns>HttpResponseMessage</returns>
        //Delete - api/posts
        [HttpDelete]
        public HttpResponseMessage DeletePost(string id)
        {
            try
            {
                Posts post = db.Posts.FirstOrDefault(p => p.id == new Guid(id)); 
                if(post != null)
                {
                    db.Posts.Remove(post);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: {ex.Message} - {ex.ToString()}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
