using Business.Constants;
using Core.Utilities.Results;
using Project.Business.Abstract;
using Project.Core.Utilities.Business;
using Project.DataAccess.Abstract;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Business.Concrete
{

    public class StudentManager : IStudentService
    {
        private IUnitOfWork _uow;

        public StudentManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IResult Add(Student student)
        {
            IResult result = BusinessRules.Run(CheckIfStudentNameSurnameExists(student.Name,student.Surname),
                                               CheckIfStudentRegistrationDateBeforeThisYear(student.RegistrationDate));
            if (result != null)
            {
                return result;
            }
            _uow.student.Add(student);
            _uow.SaveChanges();
            return new SuccessResult(Messages.StudentAdded);
        }

       

        public IDataResult<List<Student>> GetAll()
        {
            return new SuccessDataResult<List<Student>>(_uow.student.GetAll(), Messages.StudentsListed);

        }

        public IDataResult<List<Student>> GetAllByStatus(int status)
        {

            return new SuccessDataResult<List<Student>>(_uow.student.GetAll(s => s.StatusOfStudent == status));

        }

        public IDataResult<Student> GetById(int studentId)
        {
            return new SuccessDataResult<Student>(_uow.student.Get(s => s.StudentId == studentId));

        }

        public IDataResult<List<Student>> GetStudentByCourseId(int courseId)
        {
            return new SuccessDataResult<List<Student>>(_uow.student.GetAll(s =>_uow.studentCourse.GetAll(sc=>sc.CourseId==courseId)
                                                                                                    .Select(sc=>sc.StudentId)
                                                                                                    .Contains(s.StudentId) ));

        }

        public IResult Update(Student student)
        {
            _uow.student.Update(student);
            _uow.SaveChanges();
            return new SuccessResult(Messages.StudentUpdated) ;


        }
        public IResult Delete(Student student)
        {
            _uow.student.Delete(student);
            _uow.SaveChanges();
            return new SuccessResult(Messages.StudentDeleted);


        }
        private IResult CheckIfStudentNameSurnameExists(string studentName, string studentSurName)
        {
            var result = _uow.student.GetAll(s => s.Name == studentName&&s.Surname==studentSurName).Any();
            if (result)
            {
                return new ErrorResult(message: Messages.StudentNameSurnameExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfStudentRegistrationDateBeforeThisYear(DateTime registrationDate)
        {
            var result = registrationDate.Year < DateTime.Now.Year;
            if (result)
            {
                return new ErrorResult(message: Messages.YearOfRegistrationDateLowerThanThisYear);
            }
            return new SuccessResult();
        }
    }
}
