using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Inquiry
    {
        public int Id { get; set; }
        public String GameName { get; set; }
        public Customer Customer { get; set; }
        public List<int> usedIds = new List<int>();
        public Random _random = new Random();


        public Inquiry(string gameName, Customer customer)
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
        public void PrintInquiryDetails()
        {
            Console.WriteLine($"Id: {this.Id}"
                            + $"\nGame Name: {this.GameName}"
                            + $"\n\nCustomer Details");
            Console.WriteLine(new string('-', 12));
            this.Customer.PrintCustomerDetails();
        }
    }
}

