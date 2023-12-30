using Lesson29.Interfaces.Models;

namespace Lesson28.ViewModes
{
    internal class StudentViewModel : IPerson
    {
        internal string UserName;

        public Guid? StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public IEnumerable<object> Subjects { get; internal set; }
    }
}
