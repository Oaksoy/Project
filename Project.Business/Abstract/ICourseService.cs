using Core.Utilities.Results;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<Course>> GetAll();  
        IDataResult<List<Course>> GetCourseByStudentId(int studentId);
       IDataResult<Course> GetById(int courseId);
        IResult Add(Course course);
        IResult Update(Course course);
    }
}
