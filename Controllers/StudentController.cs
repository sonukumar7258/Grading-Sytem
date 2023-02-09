using Microsoft.AspNetCore.Mvc;
using GradingModule.Data;
using GradingModule.Models;
using GradingModule.Dtos;

namespace GradingModule.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGradingModuleRepo _repository;

        public StudentController(IGradingModuleRepo Repository)
        {
            _repository = Repository;
        }
        // GET api/students
        [HttpGet("AllStudents")]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return Ok(students);
        }

         [HttpGet("GetCategories")]
        public ActionResult<IEnumerable<Category>> GetReleventCategories(CreateMarksCalculationDtos Data)
        {
            var categories = _repository.getReleventCategoryData(Data);
            
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id1}/{id2}/{id3}")]
        public ActionResult<IEnumerable<Category>> GetCategoryWiseData(String id1,string id2,string id3)
        {
            GetCategoryWiseDtos Data = new GetCategoryWiseDtos();
            Data.stud_id = id1;
            Data.course_id = id2;
            Data.CategoryName = id3;

            var categories = _repository.getCategoryWiseStudents(Data);
            
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id1}/{id2}")]

        public ActionResult<IEnumerable<Marks>> getTotalMarks(String id1,string id2)
        {
            var Totalmarks = _repository.GetMarks(id1,id2);
            List<Marks> marks = new List<Marks>();
            if (Totalmarks == null)
                return NotFound();

            marks.Add(Totalmarks);
            return Ok(marks);
        }

        
        // GET api/students/{id}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(string id)
        {
            var studentItem = _repository.GetStudentById(id);
            if (studentItem != null)
                return(Ok(studentItem));
            else
                return NotFound();
        }

        [HttpPost("insert")]
        public ActionResult<Course> InsertStudentRecord(Student studentItem)
        {
            _repository.InsertNewStudentRecord(studentItem);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetStudentById),new{Id = studentItem.id},studentItem);
        }

        [HttpPost("RegisterCourse")]
        public ActionResult<Course> RegisterStudentCourse(Registeration registeration)
        {
            _repository.AssignStudentCourse(registeration);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetStudentById),new{Id = registeration.stud_id},registeration);
        }
        
    }
}