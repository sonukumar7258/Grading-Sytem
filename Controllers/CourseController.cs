using Microsoft.AspNetCore.Mvc;
using GradingModule.Data;
using GradingModule.Models;

namespace GradingModule.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IGradingModuleRepo _repository;

        public CourseController(IGradingModuleRepo Repository)
        {
            _repository = Repository;
        }
        
        
        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            var courses = _repository.GetAllCourses();
            return Ok(courses);
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCourseById")]
        public ActionResult<Course> GetCourseById(string id)
        {
            var courseItem = _repository.GetCourseById(id);
            if (courseItem != null)
                return(Ok(courseItem));
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Course> InsertCourseRecord(Course courseItem)
        {
            _repository.InsertNewCourse(courseItem);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetCourseById),new{Id = courseItem.id},courseItem);
        }
        
    }
}