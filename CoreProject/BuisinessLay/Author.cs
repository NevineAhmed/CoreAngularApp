using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BuisinessLay
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int authorId { get; set; }
        public string author_name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
