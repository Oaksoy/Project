using Microsoft.EntityFrameworkCore;
using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EFCourseDal : EfEntityRepositoryBase<Course>, ICourseDal
    {
        public EFCourseDal(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
