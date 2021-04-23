using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AssignmentApp.Models;
using AssignmentApp.Utility;



namespace AssignmentApp.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public User Authenticate(string userName, string password)
        {
            User user = new User();
            User obj = (User)MemoryCacher.GetValue(userName);
            if (obj != null)
            {
                if (obj.Password == password)
                {
                    user = obj;
                    user.IsAuthenticated = true;
                }
                else
                    user.IsAuthenticated = false;
                
            }
            user.ClientHost = HttpContext.Current.Request.Url.Host;
            return user;
        }
    }
}
