using MinimalApi_App.Enities;

namespace MinimalApi_App.Repositorys
{
    public interface IStudentRepository
    {
        Task<Student> AddStudent(Student student);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudents();
        Task<Student> EditStudent(Student student);
        Task<bool> DeleteStudent(int id);
    }
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> _lstStudent = new List<Student>();

        public StudentRepository()
        {
            _lstStudent.Add(new Student() { id = 1, name = "ali", family = "rezai" });
            _lstStudent.Add(new Student() { id = 2, name = "naser", family = "mohamadi" });
            _lstStudent.Add(new Student() { id = 3, name = "mohamad", family = "niki" });

        }
        public Task<Student> AddStudent(Student student)
        {
            student.id = (_lstStudent.Max(x => x.id) + 1);
            _lstStudent.Add(student);
            return Task.FromResult(student);
        }

        public Task<bool> DeleteStudent(int id)
        {
            _lstStudent = _lstStudent.Where(x => x.id != id).ToList();
            return Task.FromResult(true);
        }

        public Task<Student> EditStudent(Student student)
        {
            var  find = _lstStudent.FirstOrDefault(x => x.id == student.id);
            int Index = _lstStudent.IndexOf(find);
            _lstStudent[Index] = student;
            return Task.FromResult(student);
        }

        public Task<Student> GetStudentById(int id)
        {
            var findStudent = _lstStudent.FirstOrDefault(x => x.id == id);
            return  Task.FromResult(findStudent);
        }

        public Task<List<Student>> GetStudents()
        {
            return Task.FromResult(_lstStudent.ToList());
        }
    }
}
