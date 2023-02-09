using Microsoft.AspNetCore.Mvc;
using GradingModule.Data;
using GradingModule.Models;
using GradingModule.Dtos;

namespace GradingModule.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGradingModuleRepo _repository;

        public TeacherController(IGradingModuleRepo Repository)
        {
            _repository = Repository;
        }
        // GET api/Teachers
        [HttpGet("AllTeachers")]
        public ActionResult<IEnumerable<Teacher>> GetAllTeachers()
        {
            var Teachers = _repository.GetAllTeachers();
            return Ok(Teachers);
        }
        [HttpGet("AllCategories")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var Categories = _repository.GetAllCategories();
            return Ok(Categories);
        }
        

        

        // GET api/Teachers/{id}
        [HttpGet("{id}", Name = "GetTeacherById")]
        public ActionResult<Teacher> GetTeacherById(string id)
        {
            var TeacherItem = _repository.GetTeacherById(id);
            if (TeacherItem != null)
                return(Ok(TeacherItem));
            else
                return NotFound();
        }

                // GET api/Teachers/{id}
        [HttpGet("Section/{id}", Name = "GetStudentsOfSection")]
        public ActionResult<IEnumerable<Student>> GetStudentsOfSection(string id)
        {
            var Students = _repository.GetStudentsPerSection(id);
            if (Students != null)
                return(Ok(Students));
            else
                return NotFound();
        }
        

                // GET api/Teachers/{id}
        [HttpGet("course/{id}", Name = "GetStudentsOfCourse")]
        public ActionResult<IEnumerable<Student>> GetStudentsOfCourse(string id)
        {
            var Students = _repository.GetStudentsPerCourse(id);
            if (Students != null)
                return(Ok(Students));
            else
                return NotFound();
        }





        [HttpPost("insert",Name = "InsertTeacherRecord")]
        public ActionResult<Teacher> InsertTeacherRecord(Teacher TeacherItem)
        {
            _repository.InsertNewTeacherRecord(TeacherItem);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetTeacherById),new{Id = TeacherItem.id},TeacherItem);
        }

        [HttpPost("AssignCourse",Name = "AssignTeacherCourse")]
        public ActionResult<Teacher> AssignTeacherCourse(TeacherCourse teacherCourse)
        {
            _repository.AssignTeacherCourse(teacherCourse);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetTeacherById),new{Id = teacherCourse.teacher_id},teacherCourse);
        }

        [HttpPost("CategoryMarks",Name = "CategoriesWiseMarks")]
        public ActionResult<Teacher> CategoriesWiseMarks(Category category)
        {
            _repository.SetCategoryWiseMarks(category);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetTeacherById),new{Id = category.stud_id},category);
        }

        [HttpPost("SetTotalMarks",Name = "SetTotalMarks")]
        public ActionResult<Teacher> SetTotalMarks(CreateMarksCalculationDtos marks)
        {
            _repository.giveMarksToStudents(marks.stud_id,marks.course_id);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(SetTotalMarks),new{Id = marks.stud_id},marks);
        }  

        [HttpPut("UpdateMarks")]
        public ActionResult UpdateMarks(UpdateMarksDtos updateMarksDtos)
        {
            if(updateMarksDtos == null)
                return NotFound();

            _repository.updateMarks(updateMarksDtos);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}