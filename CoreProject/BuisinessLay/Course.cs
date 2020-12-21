using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BuisinessLay
{
    public class Course
    {
        public int courseId { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public CourseLevel courseLevel { get; set; }
        public DateTime? DatePublished { get; set; }
        public float fullPrice { get; set; }

        public int authorId { get; set; }
        public Author author { get; set; }
        public IList<Tag> Tags { get; set; }


    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3

    }
}
