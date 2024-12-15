namespace HomeWork_class.Important_classes;

public class Group
{
    public Guid GroupId { get; set; }
    public string GroupName { get; set; }

    public Teacher Teacher { get; set; }

    public List<Student> students { get; set; }
    public Group()
    {

    }
    public Group(Guid id, string groupName, Teacher teacher, List<Student> students)
    {
        GroupId = id;
        GroupName = groupName;
        Teacher = teacher;
        this.students = students;
    }

    public override string ToString()
    {
        string studentsInfo = string.Join("\n-------------------\n", students.Select(s => s.ToString()));

    return $"\u001b[34mGroup Id: {GroupId}\u001b[0m\n" +
           $"Group Name: {GroupName}\n" +
           $"Teacher: {Teacher.Name} {Teacher.Surname}\n" +
           $"Students:\n{studentsInfo}";
    }
}
