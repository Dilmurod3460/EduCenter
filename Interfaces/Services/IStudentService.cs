namespace Lesson28.Interfaces.Services
{
    internal interface IStudentService
    {
        void AddStudent(Student student);
        void EnrollMember(Guid studentId, Guid groupId);
        Student GetStudentByUserName(string username);
        void GetSudents();
    }
}
