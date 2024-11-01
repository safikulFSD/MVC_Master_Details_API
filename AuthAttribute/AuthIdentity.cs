using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Evidence_api01_witAthentication.AuthAttribute
{
    public class AuthIdentity : GenericIdentity
    {
        public string Password { get; set; }
        public AuthIdentity(string name,  string password) : base(name, "Basic")
        {
            Password = password;
        }
    }
}