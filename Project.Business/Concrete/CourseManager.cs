using Business.Constants;
using Core.Utilities.Results;
using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Business.Concrete
{
    public class CourseManager:ICourseService
    {
        private IUnitOfWork _uow;

        public CourseManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult Add(Course course)
        {

            _uow.course.Add(course);
            _uow.SaveChanges();
            return new SuccessResult(Messages.CourseAdded);
        }

        public IDataResult<List<Course>> GetAll()
        {
            return new SuccessDataResult<List<Course>>(_uow.course.GetAll(), Messages.CoursesListed);

        }

        public IDataResult<Course> GetById(int courseId)
        {
            return new SuccessDataResult<Course>(_uow.course.Get(c=>c.CourseId == courseId));

        }

        public IDataResult<List<Course>> GetCourseByStudentId(int studentId)
        {
            return new SuccessDataResult<List<Course>>(_uow.course.GetAll(c => _uow.studentCourse.GetAll(sc => sc.StudentId == studentId)
                                                                                                    .Select(sc => sc.CourseId)
                                                                                                    .Contains(c.CourseId)));


        }

        public IResult Update(Course course)
        {
            _uow.course.Update(course);
            _uow.SaveChanges();
            return new SuccessResult(Messages.CourseUpdated);

        }
    }
}
