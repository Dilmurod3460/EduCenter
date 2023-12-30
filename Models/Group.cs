
using Lesson29.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace Lesson28.Models
{
    internal class Group : IName
    {
        public Group()
        {

        }

        public Group(string name)
        {
            this.Name = name;
        }

        [Key]
        public Guid GroupId { get; set; }

        [Required]
        public string Name { get; set; }
        public object Limit { get; internal set; }
    }
}
