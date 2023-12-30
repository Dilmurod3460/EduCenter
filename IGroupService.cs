namespace Lesson28.Services
{
    internal interface IGroupService
    {
        void AddGroupMember(string groupName);
        bool Equals(object? obj);
        Group GetGroup(string groupName);
        void GetGroupByName(string groupName);
        Group GetGroupMember(string groupName);
        void GetGroupMembers(string groupName);
        void GetGroups();
        void GetGroupWithGroupJoin();
        void GetGroupWithJoin();
        int GetHashCode();
        void GroupMaxLimit();
        void RowQuery();
        void TestSelectMany();
        string? ToString();
    }
}