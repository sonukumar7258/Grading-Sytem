using GradingModule.Models;
using GradingModule.Dtos;

namespace GradingModule.Data
{
    public interface IGradingModuleRepo
    {
        public void InsertNewCourse(Course course);
        public void InsertNewStudentRecord(Student student);
        public void InsertNewTeacherRecord(Teacher teacher);

        public Student GetStudentById(String id);

        public Course GetCourseById(String id);
        
        public Teacher GetTeacherById(string id);

        public IEnumerable<Student> GetAllStudents();

        public IEnumerable<Teacher> GetAllTeachers();

        public IEnumerable<Course> GetAllCourses();

        public IEnumerable<Category> GetAllCategories();

        public void AssignStudentCourse(Registeration registeration);

        public void AssignTeacherCourse(TeacherCourse teacherCourse);

        public IEnumerable<Student> GetStudentsPerSection(String section);

        public  IEnumerable<Student> GetStudentsPerCourse(String courseName);

    
        public void giveMarksToStudents(String Student_id,String Course_id);

        public void SetCategoryWiseMarks(Category category);
        
        public void updateMarks(UpdateMarksDtos updateMarksDtos);

        public IEnumerable<Category> getReleventCategoryData(CreateMarksCalculationDtos Data);

        public Category getparticularCategoryRecord(UpdateMarksDtos updateMarksDtos);

        public IEnumerable<Category> getCategoryWiseStudents(GetCategoryWiseDtos getCategoryWiseStudents);
        public Marks GetMarks(String student_id,String course_id);
        
        bool SaveChanges();
    }
}