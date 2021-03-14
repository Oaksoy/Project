using Project.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class UserManager : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("me") && password.Equals("Pa$$WoRd");
        }
    }
}
