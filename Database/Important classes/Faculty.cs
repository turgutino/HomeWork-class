namespace HomeWork_class.Important_classes;

public class Faculty
{
    public Guid FacultyId { get; set; }
    public string Name { get; set; }

    public Faculty()
    {

    }

    public Faculty(Guid id, string name)
    {
        FacultyId = id;
        Name = name;
    }

    public override string ToString() => $"Faculty ID : {FacultyId}\nFaculty Name : {Name}";
}
