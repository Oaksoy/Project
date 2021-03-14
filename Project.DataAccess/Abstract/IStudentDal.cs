using Project.Core.DataAccess;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
    }
}
