namespace HomeWork_class;
using Database;
using HomeWork_class.Enum;
using HomeWork_class.Important_classes;

internal class Program
{
    static void Main(string[] args)
    {
        DataBase db = new DataBase();

        db.Student_Add();
        db.New_Group();

        while (true)
        {
            Console.WriteLine("Secim edin:");
            Console.WriteLine("1. Telebeleri goster");
            Console.WriteLine("2. Muellimleri goster");
            Console.WriteLine("3. Qruplari goster");
            Console.WriteLine("4. Yeni telebe elave et");
            Console.WriteLine("5. Yeni qrup elave et");
            Console.WriteLine("6. Telebe sil");
            Console.WriteLine("7. Qrupu sil");
            Console.WriteLine("0. Cixis");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    db.Show_All_Students();
                    break;

                case "2":
                    db.Show_All_Teachers();
                    break;

                case "3":
                    db.Show_AllGroups();
                    break;

                case "4":
                    db.Add_Student_Group();
                    break;

                case "5":
                    db.Add_Group();
                    break;

                case "6":
                    db.Delete_Student(); 
                    break;

                case "7":
                    db.Delete_Group();  
                    break;

                case "0":
                    Console.WriteLine("Proqramdan cixir...");
                    return;

                default:
                    Console.WriteLine("Yanlis secim etdiniz. Zehmet olmasa duzgun secim et.");
                    break;
            }

            Console.WriteLine();
        }


    }

}
