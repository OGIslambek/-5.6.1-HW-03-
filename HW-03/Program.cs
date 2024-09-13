using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HW_03
{
    internal class Program
    {
        static string[] GetArray(int num)
        {
            string[] result = new string[num];
            return result;
        }
        static bool CheckNumber(string number, out int correctNum)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    correctNum = intnum;
                    return false;
                }
            }
            {
                correctNum = 0;
                return true;
            }
        }

        static (string name, string lastName, int age, bool hasPet, string[] petNames, string[] favcolor) UserDataInput()
        {
            (string name, string lastName, int age, bool hasPet, string[] petNames, string[] favcolor) User;

            Console.WriteLine("Введите имя пользователя: ");
            User.name = Console.ReadLine();

            Console.WriteLine("Введите фамилию пользователя: ");
            User.lastName = Console.ReadLine();

            string Age;
            int intage;

            do
            {
                Console.WriteLine("Введите возраст цифрами, например 23");
                Age = Console.ReadLine();

            } while (CheckNumber(Age, out intage));


            User.age = intage;

            Console.WriteLine("Есть ли у Вас животные? Да или Нет");
            string result = Console.ReadLine();

            if (result == "Да")
            {
                User.hasPet = true;
            }
            else
            {
                User.hasPet = false;
            }

            if (User.hasPet == true)
            {
                Console.WriteLine("Введите количество питомцев");
                int petsNum = int.Parse(Console.ReadLine());

                User.petNames = GetArray(petsNum);

                for (int i = 0; i < User.petNames.Length; i++)
                {
                    Console.WriteLine($"Введите имя питомца {i + 1}");
                    User.petNames[i] = Console.ReadLine();
                }
            }
            else
            {
                User.petNames = null;
            }

            Console.WriteLine("Введите количество цветов");
            int colorNum = int.Parse(Console.ReadLine());

            User.favcolor = GetArray(colorNum);

            for (int i = 0; i < User.favcolor.Length; i++)
            {
                Console.WriteLine($"Введите любимый цвет {i + 1}");
                User.favcolor[i] = Console.ReadLine();
            }

            return User;

        }



        static void ShowUserData((string name, string lastName, int age, bool hasPet, string[] petNames, string[] favcolor) User)
        {
            Console.WriteLine($"Имя: {User.name}");
            Console.WriteLine($"Фамилия: {User.lastName}");
            Console.WriteLine($"Возраст: {User.age}");

            if (User.hasPet == true)
            {
                for (int i = 0; i < User.petNames.Length; i++)
                {
                    Console.WriteLine($"Любимый питомец {i + 1}: {User.petNames[i]}");
                }
            }
            else
            {
                Console.WriteLine("Пользователь не имеет питомцев");
            }

            Console.WriteLine($"Количество любимых цветов: {User.favcolor.Length}");

            for (int i = 0; i < User.favcolor.Length; i++)
            {
                Console.WriteLine($"Любимый цвет {i + 1}: {User.favcolor[i]}");
            }
        }

        static void Main(string[] args)
        {
            var user = UserDataInput();

            ShowUserData(user);
        }
    }
}
