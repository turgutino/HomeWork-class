using HomeWork_class.Enum;
using System.Text.RegularExpressions;

namespace HomeWork_class.Important_classes;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public Gender Gender { get; set; }
    public Faculty Faculty { get; set; }

    public DateOnly BirthDay { get; set; }

    public Student()
    {

    }
    public Student(Guid id, string name, string surname, Gender gender, Faculty faculty, DateOnly birthDay)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Gender = gender;
        Faculty = faculty;
        BirthDay = birthDay;
    }

    public override string ToString()
    {
        return $"\u001b[34mStudent Id: {Id}\u001b[0m\n" +
           $"Student Name: {Name}\n" +
           $"Student Surname: {Surname}\n" +
           $"Student Gender: {Gender}\n" +
          
           $"{Faculty}\n" +
           $"Student BirthDay: {BirthDay.ToString("yyyy-MM-dd")}";
    }
}
