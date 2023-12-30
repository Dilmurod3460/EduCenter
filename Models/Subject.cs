using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Lesson29.Interfaces.Models;

namespace Lesson28.Models
{
    internal class Subject : IName
    {
        [Key]
        public Guid SubjectId { get; set; }

        [Column(Order = 2)]
        public string Description { get; set; }

        [MaxLength(100)]
        [Column("SubjectName", Order = 1)]
        public string Name { get; set; }
    }
}
