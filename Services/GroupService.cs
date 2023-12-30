using Lesson28.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Lesson28.Services
{
    internal class 
        GroupService : IGroupService
    {
        public GroupService()
        {
        }

        public void AddGroupMember(string groupName)
        {
            var db = new EduCenterDB();
            var group = new Group(groupName);
            db.Add(group);
            db.SaveChanges();
        }

        public Group GetGroup(string groupName)
        {
            var db = new EduCenterDB();
            var group = db.Groups.FirstOrDefault(student => student.Name.Equals(groupName));
            return group;
        }

        public void GetGroups()
        {

            var db = new EduCenterDB();
            var groupMembers = db.GroupMembers
                .Select(member => new StudentViewModel()
                {
                    FirstName = member.Student.FirstName,
                    LastName = member.Student.LastName,
                    StudentId = member.Student.StudentId,
                }).ToList();

            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"{groupMember.FirstName}-{groupMember.LastName}");
            }
        }
        public void GetGroupMembers(string groupName)
        {
            var db = new EduCenterDB();
            var groupMembers = db.GroupMembers.Where(student => student.Group.Name.Equals(groupName))
                .Select(member => new StudentViewModel()
                {
                    FirstName = member.Student.FirstName,
                    LastName = member.Student.LastName,
                    StudentId = member.Student.StudentId,
                }).ToList();

            var groupMembersSQL = db.GroupMembers.Where(student => student.Group.Name.Equals(groupName))
                .Select(member => new StudentViewModel()
                {
                    FirstName = member.Student.FirstName,
                    LastName = member.Student.LastName,
                    StudentId = member.Student.StudentId,
                }).ToQueryString();

            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"{groupMember.FirstName}-{groupMember.LastName}");
            }
        }

        internal object GetGroupMembers()
        {
            throw new NotImplementedException();
        }

        internal object GetGroup()
        {
            throw new NotImplementedException();
        }
    }
}
