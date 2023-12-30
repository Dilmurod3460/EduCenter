
using Lesson29.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace Lesson28.Models
{
    internal class Teacher : IPerson
    {
        [Key]
        public Guid TeacherId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
    }
}
