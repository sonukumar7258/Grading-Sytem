using GradingModule.Dtos;
using GradingModule.Models;

namespace GradingModule.Data
{

    public class MockGradingRepo : IGradingModuleRepo
    {
        public void AssignStudentCourse(Registeration registeration)
        {
            throw new NotImplementedException();
        }

        public void AssignTeacherCourse(TeacherCourse teacherCourse)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = new List<Course>
            {
                new Course{id = "CS3002",name = "IS",credithours = 3,pre_requisite = "Computer Networking"},
                new Course{id = "CS1002",name = "IPT",credithours = 3,pre_requisite = ".NET"}
            };
            return courses;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> getCategoryWiseStudents(GetCategoryWiseDtos getCategoryWiseStudents)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(string id)
        {
            return new Course{id = "CS1002",name = "IPT",credithours = 3,pre_requisite = ".NET"};
        }

        public Marks GetMarks(string student_id, string course_id)
        {
            throw new NotImplementedException();
        }

        public Category getparticularCategoryRecord(UpdateMarksDtos updateMarksDtos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> getReleventCategoryData(CreateMarksCalculationDtos Data)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsPerCourse(string courseName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsPerSection(string section)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherById(string id)
        {
            throw new NotImplementedException();
        }

        public void giveMarksToStudents(Marks marks)
        {
            throw new NotImplementedException();
        }

        public void giveMarksToStudents()
        {
            throw new NotImplementedException();
        }

        public void giveMarksToStudents(string Student_id, string Course_id)
        {
            throw new NotImplementedException();
        }

        public void InsertNewCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void InsertNewStudentRecord(Student student)
        {
            throw new NotImplementedException();
        }

        public void InsertNewTeacherRecord(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SetCategoryWiseMarks(Category category)
        {
            throw new NotImplementedException();
        }
        public void updateMarks(UpdateMarksDtos updateMarksDtos)
        {
            throw new NotImplementedException();
        }
    }
}