using Exercicio_Composicao2.Entites.Enums;
using System.Collections.Generic;
namespace Exercicio_Composicao2.Entites
{
    class Worker
    {
        public string Name { get; set; }
        public WorkLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<HourContrats> Contracts = new List<HourContrats>();

        public Worker(string name, WorkLevel level, double baseSalary, Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
            Contracts = new List<HourContrats>();
        }

        public void AddContract(HourContrats contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContrats contract)
        {
            Contracts.Remove(contract);      
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach(HourContrats contract in Contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }


    }
}
