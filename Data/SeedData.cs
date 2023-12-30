using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson29.Data
{
    internal class SeedData
    {
        private Guid dotNetGroupId = Guid.Parse("6561e66a-29a5-47f2-a22b-ca47c8c38f24");
        private Guid nodeJSGroupId = Guid.Parse("05fedfbc-95c7-4981-a7dd-af8cfd54e95c");
        EduCenterDB db = new EduCenterDB();
        public SeedData()
        {
            //db.Database.EnsureCreated();
            db.Database.Migrate();
            //AddGroup();
        }

        void AddGroup()
        {
            string dotNetGroupName = ".Net Group"; // default group
            string nodeJsGroupName = "NodeJS"; // default group

            if (!db.Groups.Any(l => l.GroupId.Equals(dotNetGroupId)))
            {
                db.Add(new Group()
                {
                    GroupId = dotNetGroupId,
                    Name = dotNetGroupName,
                });
            }

            if (!db.Groups.Any(l => l.GroupId.Equals(nodeJSGroupId)))
            {
                db.Add(new Group()
                {
                    GroupId = nodeJSGroupId,
                    Name = nodeJsGroupName,
                });
            }

            db.SaveChanges();
        }
    }
}
