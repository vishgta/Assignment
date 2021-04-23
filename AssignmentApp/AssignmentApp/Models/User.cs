using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentApp.Models
{
    public class User
    {
        #region Initial Properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } 
        public string Domain { get; set; }
        #endregion

        #region Additional Properties
        public bool IsAuthenticated { get; set; }
        public string ClientHost { get; set; }
        #endregion
    }
}