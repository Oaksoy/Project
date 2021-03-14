
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Project.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Concrete.EntityFramework
{

    public class EFUnitOfWork : IUnitOfWork
    {

        #region Private Properties
        private bool _disposed;
        private DbContext _dbContext;
        private IDbContextTransaction _transaction;
        #endregion Private Properties

        #region Public Repos
        public ICourseDal course { get; }
        public IStudentDal student { get; }
        public IStudentCourseDal studentCourse { get; }
        #endregion Public Repos

        #region CTor
        public EFUnitOfWork(DbContext dbContext, ICourseDal _course, IStudentDal _student, IStudentCourseDal _studentCourse)
        {
            _dbContext = dbContext;
            _transaction = _dbContext.Database.BeginTransaction();
            course = _course;
            student = _student;
            studentCourse = _studentCourse;
        }
        ~EFUnitOfWork()
        {
            dispose(false);
        }
        #endregion CTor

        #region Private Methods
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }
                _disposed = true;
            }
        }

        #endregion Private Methods
        
        #region Public Methods
        public int SaveChanges()
        {
            try
            {
                int changedRowCount = _dbContext.SaveChanges();
                this.Commit();
                return changedRowCount;
            }
            catch
            {
                _transaction.Rollback();
                return 0;
            }
        }
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbContext.Database.BeginTransaction();
            }
        }
       

        #endregion Public Methods

       

        

        


    }

}
