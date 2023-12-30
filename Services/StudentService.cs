using Lesson28.Interfaces.Services;

namespace Lesson28.Services
{
    internal class StudentService : IStudentService
    {
        public void AddStudent(Student student)
        {
            var db = new EduCenterDB();
            db.Add(student);
            db.SaveChanges();
        }

        public void GetSudents()
        {
            var db = new EduCenterDB();
            var students = db.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.UserName}");
            }
        }

        public void EnrollMember(Guid studentId, Guid groupId)
        {
            var db = new EduCenterDB();
            var member = new GroupMember()
            {
                GroupId = groupId,
                StudentId = studentId,
            };
            db.Add(member);
            db.SaveChanges();
        }

        public Student GetStudentByUserName(string username)
        {
            var db = new EduCenterDB();
            var student = db.Students.FirstOrDefault(student => student.UserName.Equals(username));
            return student;
        }

        internal void GetGroupGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}
