using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SF.Unit5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string LastName, int Age, bool HasPets, int CountPets, string[] NamePets, string[] FavColor, int CountColor) Anketa;

            //Пользователь
            Console.Write("Введите имя: ");
            Anketa.Name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            Anketa.LastName = Console.ReadLine();

            string age;
            int intAge;
            do
            {
                Console.Write("Введите возраст: ");
                age = Console.ReadLine();

            } while (CheckNum(age, out intAge));

            Anketa.Age = intAge;

            // Животные
            Anketa.CountPets = 0;
            Anketa.HasPets = CheckHasPets();

            if (Anketa.HasPets)
            {
                Anketa.CountPets = EnterCountPets();
                Anketa.NamePets = EnterNamePets(Anketa.CountPets);
            }
            else
            {
                Anketa.NamePets = null;
            }

            // Цвета
            Anketa.CountColor = EnterCountColor();
            Anketa.FavColor = NameColor(Anketa.CountColor);

            AnketaUser(Anketa.Name, Anketa.LastName, Anketa.Age, Anketa.HasPets, Anketa.CountPets, Anketa.NamePets, Anketa.FavColor);
        }

        // Проверка на животных
        static bool CheckHasPets()
        {
            Console.Write("\nУ вас есть домашние животные? да / нет: ");
            string pet = Console.ReadLine();

            if (pet == "да")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Количество животных
        static int EnterCountPets()
        {
            string Pets;
            int PetsNum;
            do
            {
                Console.Write("Введите количество животных: ");
                Pets = Console.ReadLine();

            } while (CheckNum(Pets, out PetsNum));

            return Convert.ToInt32(PetsNum);
        }

        // Клички животных
        static string[] EnterNamePets(int count)
        {
            var result = new string[count];
            Console.WriteLine("Введите клички животных: ");

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(i + 1 + ". ");
                result[i] = Console.ReadLine();
            }

            return result;
        }

        // Запрашиваем количество цвета
        static int EnterCountColor()
        {
            string Color;
            int intColor;
            do
            {
                Console.Write("\nВведите сколько у вас любимых цветов: ");
                Color = Console.ReadLine();

            } while (CheckNum(Color, out intColor));

            return Convert.ToInt32(Color);
        }

        // Названия цветов
        static string[] NameColor(int count)
        {
            var result = new string[count];
            Console.WriteLine("Введите ваши любимые цвета: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(i + 1 + ". ");
                result[i] = Console.ReadLine();
            }

            return result;
        }

        // Проверка на корректность
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            corrnumber = 0;
            return true;
        }

        // Данные пользователя
        static void AnketaUser(string userName, string userLastName, int userAge, bool userHasPets, int userCountPets, string[] userNamePets, string[] userNameColor)
        {
            Console.WriteLine();
            Console.WriteLine($"Ваше имя: {userName}");
            Console.WriteLine($"Ваша фамилия: {userLastName}");
            Console.WriteLine($"Вам {userAge} лет");
            if (userHasPets)
            {
                Console.WriteLine($"Количесвто ваших животных: {userCountPets}");
                Console.WriteLine("Клички ваших животных: ");

                for (int i = 0; i < userNamePets.Length; i++)
                {
                    Console.Write(i + 1 + " ");
                    Console.WriteLine(userNamePets[i]);
                }
            }
            else
            {
                Console.WriteLine("У каждого должен быть хотя бы 1 котик!!!");
            }

            Console.WriteLine("Ваши любимые цвета: ");

            for (int i = 0; i < userNameColor.Length; i++)
            {
                Console.Write(i + 1 + " ");
                Console.WriteLine(userNameColor[i]);
            }


        }
    }
}
