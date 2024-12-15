using HomeWork_class.Enum;

namespace HomeWork_class.Important_classes;
public class Teacher
{
    public Guid TeacherId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public Gender Gender { get; set; }
    public string Speciality { get; set; }

    public DateOnly BirthDay { get; set; }

    public Teacher()
    {

    }
    public Teacher(Guid id, string name, string surname, Gender gender, string speciality, DateOnly birthDay)
    {
        TeacherId = id;
        Name = name;
        Surname = surname;
        Gender = gender;
        Speciality = speciality;
        BirthDay = birthDay;
    }
    public override string ToString()
    {
        return $"Id: {TeacherId}\n" +
           $"Name: {Name}\n" +
           $"Surname: {Surname}\n" +
           $"Gender: {Gender}\n" +
           $"Speciality: {Speciality}\n" +
           $"BirthDay: {BirthDay.ToString("yyyy-MM-dd")}";
    }
}
