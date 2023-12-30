using Microsoft.EntityFrameworkCore;

internal static class GroupServiceHelpers
{




    public static void GetGroupMembers(string groupName)
    {
        var db = new EduCenterDB();
        var groupMembers = db.GroupMembers.Where(student => student.Group.Name.Equals(groupName))
            .Select(member => new StudentViewModel()
            {
                FirstName = member.Student.FirstName,
                LastName = member.Student.LastName,
                StudentId = member.Student.StudentId,
            }).ToList();

        var groupMembersSQLWithSelect = db.GroupMembers.Where(student => student.Group.Name.Equals(groupName))
            .Select(member => new StudentViewModel()
            {
                FirstName = member.Student.FirstName,
                LastName = member.Student.LastName,
                StudentId = member.Student.StudentId,
            }).ToQueryString();

        var groupMembersSQLWithInclude = db.GroupMembers.Include(groupMember => groupMember.Student).Where(student => student.Group.Name.Equals(groupName)).ToQueryString();

        foreach (var groupMember in groupMembers)
        {
            Console.WriteLine($"{groupMember.FirstName}-{groupMember.LastName}");
        }
    }
}