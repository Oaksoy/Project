using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IUserService
    {
        bool ValidateCredentials(String username, String password);
    }
}
