using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace M5_IT_PROJECT
{
    internal class Program
    {
        static (string Name, string SurName, int Age, string[] PetName, string[] Colors) DataInput() // Имя, фамилия, лет, наличие питомцев, клички
        {

            (string Name, string SurName, int Age, string[] PetName, string[] Colors) User;

            string PetFactString; // Ответ да/нет о наличии питомцев
            int PetNumber = 0; // количество питомцев
            string ColorFactString; // Ответ да/нет о наличии цветов
            int ColorNumber = 0; // количество цветов
            bool CorrectInput;

            Console.WriteLine("Введите имя:");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            User.SurName = Console.ReadLine();

            Console.WriteLine("Введите возраст:");
            User.Age = int.Parse(CheckInput());

            Console.WriteLine("Есть ли у вас питомцы? (Да/Нет)");
            PetFactString = Console.ReadLine();

            if (PetFactString == "Да")
            {
                Console.WriteLine("Сколько у вас питомцев?");
                PetNumber = int.Parse(CheckInput());
                User.PetName = PetName(PetNumber); // Клички в массив кортежа
 
            }
            else
            {
                var NoPet = new string[1];
                NoPet[0] = "Нет питомцев";
                User.PetName = NoPet;
            }

            Console.WriteLine("Есть ли у вас любимые цвета? (Да/Нет)");
            ColorFactString = Console.ReadLine();

            if (ColorFactString == "Да")
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                ColorNumber = int.Parse(CheckInput());
                User.Colors = Color(ColorNumber); // Цвета в массив кортежа
            }
            else
            {
                var Color = new string[1];
                Color[0] = "Нет любимых цветов";
                User.Colors = Color;
            }

            return User;
        }

        static string CheckInput()
        {
            int IntInput;
            string Input = Console.ReadLine();

            if (int.TryParse(Input, out IntInput))
            {
                if (int.Parse(Input) <= 0)
                {
                    CheckInput();
                }
                return Input;
            }
            else
            {
                CheckInput();
                return Input;
            }

            

        }

        static string[] PetName(int PetNumber) // Заполнение кличками питомцев массива и отправка в метод DataInput
        {
            string[] PetNameArr = new string[PetNumber];

            for (int i = 0; i < PetNumber; i++)
            {
                Console.WriteLine("Как зовут вашего {0} питомца?", i + 1);
                PetNameArr[i] = Console.ReadLine();
            }
            
            return PetNameArr;
        }

        static string[] Color(int ColorNumber) // Заполнение кличками питомцев массива и отправка в метод DataInput
        {
            string[] ColorNameArr = new string[ColorNumber];

            for (int i = 0; i < ColorNumber; i++)
            {
                Console.WriteLine("Какой ваш {0} любимый цвет?", i + 1);
                ColorNameArr[i] = Console.ReadLine();
            }

            return ColorNameArr;
        }

        static void DataOutput()
        {
            var User = DataInput();

            Console.Clear();

            Console.WriteLine("Ваше имя: {0} \nВаша фаилия: {1} \nВаш возраст: {2}", User.Name, User.SurName, User.Age);

            Console.Write("Ваших питомцев зовут: ");
            foreach(string i in User.PetName)
            {
                Console.Write(i + " "); 
            }

            Console.WriteLine();
            Console.Write("Ваши любимые цвета: ");
            foreach (string i in User.Colors)
            {
                Console.Write(i + " ");
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            DataOutput();
        }
    }
}
