using GradingModule.Models;
using GradingModule.Dtos;
using AutoMapper;

namespace GradingModule.Data
{
    public class SqlGradingModuleRepo : IGradingModuleRepo
    {
        private readonly GradingModuleContext _context;
        private readonly IMapper _mapper;

        public SqlGradingModuleRepo(GradingModuleContext context,IMapper Mapper)
        {
            _context = context;   
            _mapper = Mapper;
        }
        public void AssignStudentCourse(Registeration registeration)
        {
            if (registeration == null)
            {
                 throw new ArgumentNullException(nameof(registeration));
            }
            _context.registerations.Add(registeration);
        }

        public void AssignTeacherCourse(TeacherCourse teacherCourse)
        {
            if (teacherCourse == null)
            {
                 throw new ArgumentNullException(nameof(teacherCourse));
            }
            _context.teacherCourses.Add(teacherCourse);
        }

        public IEnumerable<Category> GetAllCategories()
        {
           return _context.Categories.ToList();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.courses.ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.students.ToList();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _context.teachers.ToList();
        }

        public IEnumerable<Category> getCategoryWiseStudents(GetCategoryWiseDtos Data)
        {
            var categoryRecords = _context.Categories.Where(p=> p.stud_id == Data.stud_id && p.course_id == Data.course_id && p.CategoryName == Data.CategoryName);
            if (categoryRecords == null)
                throw new ArgumentNullException(nameof(categoryRecords));

            return categoryRecords;
        }

        public Course GetCourseById(string id)
        {
            return _context.courses.FirstOrDefault(p => p.id == id);
        }

        public Marks GetMarks(string student_id, string course_id)
        {
            return _context.marks.FirstOrDefault(p => p.stud_id == student_id && p.course_id == course_id);
        }

        public Category getparticularCategoryRecord(UpdateMarksDtos updateMarksDtos)
        {
            return _context.Categories.FirstOrDefault(p => p.stud_id == updateMarksDtos.stud_id && p.course_id == updateMarksDtos.course_id
            && p.CategoryName == updateMarksDtos.CategoryName && p.CategoryNameSequence == updateMarksDtos.CategoryNameSequence);
        }

        public IEnumerable<Category> getReleventCategoryData(CreateMarksCalculationDtos Data)
        {
            var categoryRecords = _context.Categories.Where(p=> p.stud_id == Data.stud_id && p.course_id == Data.course_id);
            if (categoryRecords == null)
                throw new ArgumentNullException(nameof(categoryRecords));

            return categoryRecords;
        }

        public Student GetStudentById(string id)
        {
            return _context.students.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Student> GetStudentsPerCourse(string courseName)
        {
            var AllRegisterations = _context.registerations.Where(p => p.course_id == courseName);
            List<Student> records = new List<Student>();
            foreach(Registeration r in AllRegisterations)
            {
                records.Add(GetStudentById(r.stud_id)); 
            }
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }
            return records;
        }

        public IEnumerable<Student> GetStudentsPerSection(string section)
        {
            var AllRegisterations = _context.registerations.Where(p => p.section == section);
            List<Student> records = new List<Student>();
            foreach(Registeration r in AllRegisterations)
            {
                records.Add(GetStudentById(r.stud_id)); 
            }
            if (records == null)
            {
                throw new ArgumentNullException(nameof(records));
            }
            return records;
        }

        public Teacher GetTeacherById(string id)
        {
            return _context.teachers.FirstOrDefault(p => p.id == id);
        }

        public void giveMarksToStudents(String Student_id,String course_id)
        {
            
            Student studentRecord = GetStudentById(Student_id);
            var categoryMatchedRecords = _context.Categories.Where(p=> p.stud_id == Student_id && p.course_id == course_id);
            double totalMarksOfCourse = 0;

            foreach(Category c in categoryMatchedRecords)
            {   
                totalMarksOfCourse = totalMarksOfCourse + c.marks;
            }
            
            String Grade = "-";

            if(totalMarksOfCourse < 50)
                Grade = "F";
            else if(totalMarksOfCourse >= 50 && totalMarksOfCourse < 54)
                Grade = "D";
            else if(totalMarksOfCourse >= 54 && totalMarksOfCourse < 58)
                Grade = "D+";
            else if(totalMarksOfCourse >= 58 && totalMarksOfCourse < 62)
                Grade = "C-";
            else if(totalMarksOfCourse >= 62 && totalMarksOfCourse < 66)
                Grade = "C";
            else if(totalMarksOfCourse >= 66 && totalMarksOfCourse < 70)
                Grade = "C+";
            else if(totalMarksOfCourse >= 70 && totalMarksOfCourse < 74)
                Grade = "B-";
            else if(totalMarksOfCourse >= 74 && totalMarksOfCourse < 78)
                Grade = "B";
            else if(totalMarksOfCourse >= 78 && totalMarksOfCourse < 82)
                Grade = "B+";
            else if(totalMarksOfCourse >= 82 && totalMarksOfCourse < 86)
                Grade = "A-";
            else if(totalMarksOfCourse >= 86 && totalMarksOfCourse < 90)
                Grade = "A";
            else if(totalMarksOfCourse >=90  && totalMarksOfCourse < 101)
                Grade = "A+";
            else
            {
                Grade = "-";
            }
            Marks Currentmarks = new Marks{stud_id = Student_id,course_id = course_id,marks = totalMarksOfCourse,semester = studentRecord.current_sem,grade = Grade};
             if (Currentmarks == null)
            {
                 throw new ArgumentNullException(nameof(Currentmarks));
            }
            _context.marks.Add(Currentmarks);
        }

        public void InsertNewCourse(Course course)
        {
            if (course == null)
            {
                 throw new ArgumentNullException(nameof(course));
            }
            _context.courses.Add(course);
        }

        public void InsertNewStudentRecord(Student student)
        {
            if (student == null)
            {
                 throw new ArgumentNullException(nameof(student));
            }
            _context.students.Add(student);
        }

        public void InsertNewTeacherRecord(Teacher teacher)
        {
           if (teacher == null)
            {
                 throw new ArgumentNullException(nameof(teacher));
            }
            _context.teachers.Add(teacher);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void SetCategoryWiseMarks(Category category)
        {
            if (category == null)
            {
                 throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Add(category);
        }

        public void updateMarks(UpdateMarksDtos updateMarksDtos)
        {
            Category RecordToUpdate = getparticularCategoryRecord(updateMarksDtos);

            if (RecordToUpdate == null)
            {
                throw new ArgumentNullException(nameof(updateMarksDtos)); 
            } 
            _mapper.Map(updateMarksDtos,RecordToUpdate);  
        }
    }
}

