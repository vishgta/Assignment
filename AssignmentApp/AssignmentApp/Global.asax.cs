using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AssignmentApp.Models;
using AssignmentApp.Utility;
using System.Web.Script.Serialization;
using System.IO;

namespace AssignmentApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);                     
            

            // load data from JSON file
            //get the Json filepath  
            string abcJsonFile = Server.MapPath("~/JSON/abc.json");
            //deserialize JSON from file  
            string abcJson = System.IO.File.ReadAllText(abcJsonFile);
            JavaScriptSerializer abcSer = new JavaScriptSerializer();
            var abcUserList = abcSer.Deserialize<List<User>>(abcJson);

            string xyzJsonFile = Server.MapPath("~/JSON/xyz.json");
            //deserialize JSON from file  
            string xyzJson = System.IO.File.ReadAllText(xyzJsonFile);
            JavaScriptSerializer xyzSer = new JavaScriptSerializer();
            var xyzUserList = xyzSer.Deserialize<List<User>>(xyzJson);

            foreach (User user in abcUserList)
            {
                MemoryCacher.Add(user.UserName, user, DateTimeOffset.Now.AddMonths(1));
            }
            foreach (User user in xyzUserList)
            {
                MemoryCacher.Add(user.UserName, user, DateTimeOffset.Now.AddMonths(1));
            }


        }
    }
}
