using BlogIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogIt.Auth
{
    /// <summary>
    /// Check if the login request is a valid user present in the database with correct credentials.
    /// </summary>
    /// <param name="username">Stored Procedure Name</param>
    /// <param name="password">DataTable as input</param>
    /// <returns>Success or not</returns>
    public class BlogAuth
    {
        public static bool Login (string username, string password)
        {
            try
            {
                DatabaseContext db = new DatabaseContext();
                return db.Users.Any(user => user.userName.Equals(username, StringComparison.OrdinalIgnoreCase)
                                &&
                                user.passwordHash.Equals(password));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: [Method: Login] {ex.Message} - {ex.ToString()}");
                return false;
            }
        }
    }
}