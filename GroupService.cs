using Lesson28.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
namespace Lesson28.Services
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    internal class GroupService : IGroupService
    {
        public static void AddGroup(string groupName)
        {
            var db = new EduCenterDB();
            var group = new Group(groupName);
            db.Add(group);
            db.SaveChanges();
        }

        public Group GetGroupMember(string groupName)
        {
            var db = new EduCenterDB();
            var group = db.Groups.FirstOrDefault(student => student.Name.Equals(groupName));
            return group;
        }

        public void GetGroupByName(string groupName)
        {
            try
            {
                using (var db = new EduCenterDB())
                {
                    var firstGroup = db.Groups.FirstOrDefault(f => f.GroupId == Guid.Parse("05fedfbc-95c7-4981-a7dd-af8cfd54e95c"));

                    firstGroup.Name = ".NET Group";

                    db.SaveChanges();
                }

                //foreach (var group in groups)
                //{
                //    Console.WriteLine($"{group.Name}");
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void GetGroupsMember()
        {
            try
            {
                using (var db = new EduCenterDB())
                {
                    var groupsQuery = db.Groups;
                    var groups = groupsQuery;
                    var firstGroup = groups.FirstOrDefault(f => f.GroupId == Guid.Parse("05fedfbc-95c7-4981-a7dd-af8cfd54e95c"));

                    firstGroup.Name = "LKamolidasdasd as";

                    db.SaveChanges();
                }

                //foreach (var group in groups)
                //{
                //    Console.WriteLine($"{group.Name}");
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void GetGroupWithJoin()
        {
            var db = new EduCenterDB();
            var groups = db.Groups;
            var groupMembers = db.GroupMembers.Join(groups, groupMember => groupMember.GroupId, group => group.GroupId, (groupMember, group) => new GroupMemberViewModel
            {
                GroupMemberId = groupMember.GroupMemberId,
                GroupName = group.Name,
            }).ToList();
            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"{groupMember.GroupMemberId} {groupMember.GroupName}");
            }
        }

        public void GetGroupWithGroupJoin()
        {
            var db = new EduCenterDB();

            var query = from b in db.GroupMembers
                        join p in db.Groups
                            on b.GroupId equals p.GroupId into grouping
                        select new { b, grouping };

            var groups = db.Groups.AsEnumerable();
            var groupMembers = db.GroupMembers.AsEnumerable().GroupJoin(groups, groupMember => groupMember.GroupId, group => group.GroupId, (groupMember, group) => new
            {
                GroupMemberId = groupMember.GroupMemberId,
                Groups = group,
            });

            var asdas = groupMembers.ToList();

            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"----------------------------------- -------------------------------------- ------------------------------");
                foreach (var item in groupMember.Groups)
                {
                    Console.WriteLine($"{item.Name} {item.Limit}");
                }
            }
        }

        public void GroupMaxLimit()
        {
            var db = new EduCenterDB();

            var group_1 = db.Groups.OrderByDescending(group => group.Limit).FirstOrDefault();

            var group_2 = db.Groups.AsEnumerable().MaxBy(group => group.Limit);

            Console.WriteLine($"{group_2.Name} - {group_2.Limit}");
        }

        public void TestSelectMany()
        {
            var student_1 = new StudentViewModel()
            {
                FirstName = "Anvar",
                Subjects = new List<Subject>()
                {
                    new Subject()
                    {
                        Name = "1",
                    },
                    new Subject()
                    {
                        Name = "2",
                    },
                    new Subject()
                    {
                        Name = "3",
                    },
                }
            };

            var student_2 = new StudentViewModel()
            {
                FirstName = "Kamoliddin",
                Subjects = new List<Subject>()
                {
                    new Subject()
                    {
                        Name = "11",
                    },
                    new Subject()
                    {
                        Name = "21",
                    },
                    new Subject()
                    {
                        Name = "31",
                    },
                }
            };

            var students = new List<StudentViewModel>() { student_1, student_2 };

            var allSubjects = new List<Subject>();
            //foreach (var student in students)
            //{
            //    allSubjects.AddRange(student.Subjects);
            //}

            var allSubjects_1 = students.SelectMany(student => student.Subjects).ToList();
            Console.WriteLine(allSubjects.Count);
        }

        public void RowQuery()
        {
            var db = new EduCenterDB();
            var groups = db.Groups.FromSqlRaw("select * from public.\"Groups\"").OrderByDescending(s => s.Limit).ToList();
            Console.WriteLine();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}