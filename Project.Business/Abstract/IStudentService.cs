using Core.Utilities.Results;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IStudentService
    {
        IDataResult<List<Student>> GetAll();   //ürün listesi döndürüyo
        IDataResult<List<Student>> GetAllByStatus(int status);
        IDataResult<List<Student>> GetStudentByCourseId(int courseId);
        IDataResult<Student> GetById(int studentId);
        IResult Add(Student student);
        IResult Update(Student student);
    }
}
