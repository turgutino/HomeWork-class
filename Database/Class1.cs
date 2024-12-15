using HomeWork_class.Enum;
using HomeWork_class.Important_classes;

namespace Database

{
    public class DataBase
    {

        Student student= new Student(Guid.NewGuid(), "Elvin", "Memmedov", Gender.Male, new Faculty(Guid.NewGuid(), "Engineering"), new DateOnly(2000, 5, 15));
        Student student2= new Student(Guid.NewGuid(), "Leyla", "Huseynova", Gender.Female, new Faculty(Guid.NewGuid(), "Medical"), new DateOnly(1998, 3, 22));
        Student student3 = new Student(Guid.NewGuid(), "Ramin", "Resulov", Gender.Male, new Faculty(Guid.NewGuid(), "Design"), new DateOnly(2001, 12, 1));
        Student student4 = new Student(Guid.NewGuid(), "Nigar", "Aliyeva", Gender.Female, new Faculty(Guid.NewGuid(), "Law"), new DateOnly(1999, 7, 30));
        Student student5= new Student(Guid.NewGuid(), "Tural", "Guliyev", Gender.Male, new Faculty(Guid.NewGuid(), "Business"), new DateOnly(2002, 11, 5));


        List<Student> students = new List<Student> {  };

        List<Teacher> teachers = new List<Teacher>
        {
           
            new Teacher(Guid.NewGuid(), "Gunel", "Mammadova", Gender.Female, "Fizika", new DateOnly(1990, 8, 25)),
            new Teacher(Guid.NewGuid(), "Murad", "Huseynov", Gender.Male, "Kimya", new DateOnly(1978, 11, 12))
        };

        List<Group> groups = new List<Group>();


        public void Student_Add()
        {
            students.Add(student);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);

         
        }


        public void New_Group() {

            groups.Add(new Group(Guid.NewGuid(), "1203i", new Teacher(Guid.NewGuid(), "Orxan", "Quliyev", Gender.Male, "Riyaziyyat", new DateOnly(1985, 5, 15)), new List<Student> {student,student2,student3}));

            
            groups.Add(new Group(Guid.NewGuid(), "1204b", new Teacher(Guid.NewGuid(), "Aysel", "Eliyeva", Gender.Female, "İngilis Dili", new DateOnly(1990, 3, 10)), new List<Student> {student4,student5}));
        }

        public void Add_Group()
        {
            
            if (students.Count == 0)
            {
                Console.WriteLine("Hech bir telebe movcud deyil! Evvelce telebeler elave edin.");
                return;
            }

            Console.WriteLine("Movcud Telebeler :");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].ToString()}");
            }

            Console.Write("Yeni qrup adi daxil edin : ");
            string groupName = Console.ReadLine();

            Console.WriteLine("Hansi telebeleri qrupa elave etmek isteyirsiniz? (Telebe nomrelerini daxil edin, meselen: 1, 3, 5) : ");
            string input = Console.ReadLine();
            string[] selectedStudentsIndexes = input.Split(',');

            List<Student> selectedStudents = new List<Student>();

            foreach (string index in selectedStudentsIndexes)
            {
                int studentIndex;
                if (int.TryParse(index.Trim(), out studentIndex) && studentIndex >= 1 && studentIndex <= students.Count)
                {
                    selectedStudents.Add(students[studentIndex - 1]);
                }
                else
                {
                    Console.WriteLine($"Yanlis telebe nomresi : {index.Trim()}. Qrupa elave olunmadi.");
                }
            }

            Console.WriteLine("Qrupa muellim elave edin:");
            Console.Write("Muellimin adi : ");
            string TeacherName = Console.ReadLine();
            Console.Write("Muellimin soyadi : ");
            string TeacherSurname = Console.ReadLine();
            Console.Write("Muellimin fenni : ");
            string Subject = Console.ReadLine();

            Teacher newTeacher = new Teacher(Guid.NewGuid(), TeacherName, TeacherSurname, Gender.Male, Subject, new DateOnly(1980, 1, 1));

            Group newGroup = new Group(Guid.NewGuid(), groupName, newTeacher, selectedStudents);

            groups.Add(newGroup);

            Console.WriteLine($"Qrup '{newGroup.GroupName}' ugurla elave edildi!");
        }

        public void Add_Student_Group()
        {

           
            if (groups.Count == 0)
            {
                Console.WriteLine("Hech bir qrup movcud deyil! Evvelce bir qrup elave edin.");
                return;
            }
            Console.Clear();

            Console.WriteLine("Movcud Qruplar:");
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {groups[i].ToString()}");
            }

            
            Console.WriteLine("Hansi qrupa telebe elave etmek isteyirsiniz? (Nomresini daxil edin) : ");
            int groupIndex;
            if (!int.TryParse(Console.ReadLine(), out groupIndex) || groupIndex < 1 || groupIndex > groups.Count)
            {
                Console.WriteLine("Yanlis secim etdiniz! Emeliyyat dayandirildi.");
                return;
            }

            Group selectedGroup = groups[groupIndex - 1];

            Console.WriteLine("Yeni telebenin melumatlarini daxil edin :");
            Console.Write("Ad : ");
            string name = Console.ReadLine();
            Console.Write("Soyad : ");
            string surname = Console.ReadLine();
            Console.Write("Cinsiyyet (Male/Female) : ");
            string genderInput = Console.ReadLine();
            Gender gender = genderInput.ToLower() == "male" ? Gender.Male : Gender.Female;
            Console.Write("Dogum ili : ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Dogum ayi : ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Dogum gunu : ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Fakulte adi : ");
            string facultyName = Console.ReadLine();

         
            Student newStudent = new Student(
                Guid.NewGuid(),
                name,
                surname,
                gender,
                new Faculty(Guid.NewGuid(), facultyName),
                new DateOnly(year, month, day)
            );

            selectedGroup.students.Add(newStudent);
            students.Add(newStudent);

            Console.WriteLine($"Telebe ugurla '{selectedGroup.GroupName}' qrupuna elave edildi!");
        }


        public void Show_All_Teachers()
        {
            Console.Clear();
            Console.WriteLine("                                                Butun Muellimler siyahisi\n   ");
            foreach (Teacher teacher in teachers)
            {
                   Console.WriteLine(teacher.ToString());
                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }
        }

        public void Show_All_Students()
        {
            Console.Clear();
            Console.WriteLine("                                                Butun Sagirdler siyahisi\n   ");
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }
        }

        public void Show_AllGroups()
        {
            Console.Clear();
            Console.WriteLine("                                                 Butun Qruplarin siyahisi\n   ");
            foreach (Group group in groups)
            {
                Console.WriteLine(group.ToString());
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                
            }
        }


        public void Delete_Student()
        {
            Console.Clear();
            if (students.Count == 0)
            {
                Console.WriteLine("Hec bir telebe movcud deyil.");
                return;
            }

            Console.WriteLine("Movcud Telebeler :");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].ToString()}");
            }

       
            Console.Write("Silmek istediyiniz telebenin nomresini daxil edin : ");
            int studentIndex;
            if (!int.TryParse(Console.ReadLine(), out studentIndex) || studentIndex < 1 || studentIndex > students.Count)
            {
                Console.WriteLine("Yanlis secim etdiniz! Emeliyyat dayandirildi.");
                return;
            }

            Student studentToDelete = students[studentIndex - 1];

            
            foreach (var group in groups)
            {


                group.students.RemoveAll(s => s.Id == studentToDelete.Id);
            }

            students.Remove(studentToDelete);

            Console.WriteLine($"'{studentToDelete.Name} {studentToDelete.Surname}' adli telebe ugurla silindi.");
        }


        public void Delete_Group()
        {
            Console.Clear();

            if (groups.Count == 0)
            {
                Console.WriteLine("Heç bir qrup movcud deyil.");
                return;
            }

            Console.WriteLine("Movcud Qruplar :");
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {groups[i].GroupName}");
            }

            Console.Write("Silmek istediyiniz qrupun nomresini daxil edin : ");
            int groupIndex;
            if (!int.TryParse(Console.ReadLine(), out groupIndex) || groupIndex < 1 || groupIndex > groups.Count)
            {
                Console.WriteLine("Yanlıs secim etdiniz! Emeliyyat dayandırıldı.");
                return;
            }

            Group groupToDelete = groups[groupIndex - 1];
            groups.RemoveAt(groupIndex - 1);

            Console.WriteLine($"'{groupToDelete.GroupName}' adlı qrup ugurla silindi.");
        }
    }
}
