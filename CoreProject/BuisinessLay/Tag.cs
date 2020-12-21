using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLay
{
    public class Tag
    {
        public int tagId { get; set; }
        public string tag_name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
