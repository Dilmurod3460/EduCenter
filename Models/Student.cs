
using Lesson29.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace Lesson28.Models
{
    internal class Student : IPerson
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
