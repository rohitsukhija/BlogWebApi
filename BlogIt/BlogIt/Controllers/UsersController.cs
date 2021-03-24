using BlogIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogIt.Controllers
{
    public class UsersController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        /// <summary>
        /// Getting all the list of Users
        /// </summary>
        /// <returns>List of Users</returns>
        //GET - api/users
        public IEnumerable<Users> Get()
        {
            return db.Users.ToList();
        }

        /// <summary>
        /// Getting single User
        /// </summary>
        /// <param name="id">Id of the User</param>
        /// <returns>User</returns>
        //GET - api/users
        public Users Get(string guid)
        {
            return db.Users.FirstOrDefault(u => u.id == new Guid(guid));
        }
    }
}
