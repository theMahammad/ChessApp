using System;
using System.Collections;
namespace SelectCustomAmountRandomName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey!Salam!Random seçiciye xoş gelmisen!Başlamaq üçün entere bas");
            ArrayList names = new ArrayList();
           
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            { Console.WriteLine("Başladıq!Neçe data daxil edilecek?");
                int length = int.Parse(Console.ReadLine());
                do
                {
                    
                    string name = Console.ReadLine();
                    names.Add(name);
                    Console.WriteLine("Daxil edildi");
                    Console.WriteLine("************");
                    length--;
                } while (length>0);
                Console.WriteLine("Elimizdeki datalar : ");
                foreach(var name in names)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("Neçe şanslı seçilecek? ;)");
                int amountOfHappies = int.Parse(Console.ReadLine());
                Console.WriteLine("Seçim başlayırr!");
                Random random = new Random();
                Console.WriteLine("Şanslılar : ");

                while(Console.ReadKey().Key == ConsoleKey.Enter && amountOfHappies>0)
                {   
                    int index = random.Next(names.Count-1);
                    Console.WriteLine($"{names[index]}");
                    names.RemoveAt(index);
                    amountOfHappies--;
                    
                    
                }
            }

        }
    }
}
