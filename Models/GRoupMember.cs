using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson28.Models
{
    internal class GroupMember
    {
        [Key]
        public Guid GroupMemberId { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }

        #region Relations

        public Group Group { get; set; }

        public Student Student { get; set; }

        #endregion Relations
    }
}
