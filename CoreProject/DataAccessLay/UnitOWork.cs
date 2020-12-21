using BuisinessLay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLay
{
    public class UnitOWork : IUnitOWork
    {
        private DbContext _context;
        public   Repository<Course> CourseRepository;
        private static Repository<Author> AuthorRepository;
        private static  Repository<Tag> TagRepository;

        public UnitOWork(DbContext context)
        {
            _context = context;
        }
        public Repository<Course> courseRepository
        {
            get {

                if (CourseRepository == null)
                {
                    
                    CourseRepository = new Repository<Course>(_context);

                }
                return CourseRepository;
                 }
        }

        Dcontext IUnitOWork._context => throw new NotImplementedException();

        public void commit()
        {
           
            _context.SaveChanges();
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
