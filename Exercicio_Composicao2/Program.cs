using Exercicio_Composicao2.Entites;
using Exercicio_Composicao2.Entites.Enums;
using System;
using System.Globalization;

namespace Exercicio_Composicao2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name:");
            string departament = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior):");
            WorkLevel level = (WorkLevel)Enum.Parse(typeof(WorkLevel), Console.ReadLine());
            Console.Write("Base salary:");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament depart = new Departament(departament);
            Worker wrk = new Worker(name, level, basesalary, depart);

            Console.Write("How many contracts to this worker?");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; num >= i; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueperhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());

                HourContrats hourcontrats = new HourContrats(date, valueperhour, duration);
                wrk.AddContract(hourcontrats);
            }
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthandyear = Console.ReadLine();

            int month = int.Parse(monthandyear.Substring(0, 2));
            int year = int.Parse(monthandyear.Substring(3));

            Console.WriteLine("Name: " + wrk.Name);
            Console.WriteLine("Departament: " + depart.Name);
            Console.WriteLine("Income for " + monthandyear + ": " + wrk.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));



        }
    }
}
