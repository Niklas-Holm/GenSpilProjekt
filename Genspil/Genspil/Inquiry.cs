using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Inquiry
    {
        private int Id;
        private String GameName;
        private Customer Customer;
        public List<int> usedIds = new List<int>();
        public Random _random = new Random();


        public Inquiry(int id, string gameName, Customer customer)
        {
            this.Id = GenerateUniqueId();
            this.GameName = gameName;
            this.Customer = customer;

        }

        // Metode til at generere ID
        private int GenerateUniqueId()
        {
            int id;
            do
            {
                id = _random.Next(10000000, 99999999);
            } while (usedIds.Contains(id));

            usedIds.Add(id);
            return id;
        }

        // Metode til at printe Inquiry
        public void PrintCustomerInfo()
        {
            Console.WriteLine($"Id: {this.Id}"
                            + $"\nGame Name: {this.GameName}"
                            + $"\nCustomer info:\n {this.Customer}");
        }
    }
}

