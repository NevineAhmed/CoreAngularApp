using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisinessLay;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLay;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

namespace WebApiProj.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;
        public CourseController( CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var list= await _courseService.GetAllCourses().ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
            
        }

        public async Task<IActionResult> GetCoursebyId(int id)
        {
            var course = await _courseService.GetbyId(id).FirstOrDefaultAsync();
            if (course == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(course);
            }
            
        }



        
    }
}