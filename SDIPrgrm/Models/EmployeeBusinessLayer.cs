using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDIPrgrm.Models
{
    public class EmployeeBusinessLayer
    {
        public bool IsValidUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}