using BuisinessLay;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLay
{
   public interface IUnitOWork : IDisposable
    {

        public  Repository<Course> courseRepository { get; }
        private static Repository<Author> AuthorRepository;
        private static Repository<Tag> TagRepository;
        public Dcontext _context { get;  }
        void commit();
        
    }
}
