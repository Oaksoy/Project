using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Abstract
{
    public interface IUnitOfWork 
    {
         ICourseDal course { get; }
         IStudentDal student { get; }
        IStudentCourseDal studentCourse { get; }
        void Commit();
         int SaveChanges();
    }
}
