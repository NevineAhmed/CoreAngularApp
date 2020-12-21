using BuisinessLay;
using DataAccessLay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ServiceLay
{
   public class CourseService
    {
        
        private readonly IUnitOWork _uow;
        public CourseService(IUnitOWork uow )
        {
            _uow = uow;
        }

       public IQueryable<Course> GetAllCourses()
        {
            var courses = _uow.courseRepository.GetAll();
            return courses;
        }

        public IQueryable<Course>  GetbyId(int id)
        {
            return _uow.courseRepository.Get(a => a.courseId == id);
        }

        public IEnumerable<Course> GetbyLevel(string level)
        {
            CourseLevel lev = (CourseLevel)Enum.Parse(typeof(CourseLevel), level);
            return _uow.courseRepository.Get(a =>a.courseLevel == lev ,a=>a.OrderBy(o=>o.DatePublished),includeProperties:"author");
        }

        public void deleteCourse(int id)
        {
            IEnumerable<Course> course = GetbyId(id);
           Course c= course.FirstOrDefault();
            _uow.courseRepository.Delete(c);
            _uow.commit();

        }

        public void updateCourse(Course course)
        {
            _uow.courseRepository.Update(course);
            _uow.commit();
        }
    }
}
