using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string AdditionalInfo { get; set; }

        // Constructor 
        public Customer(string name, string email, int phone, string additionalInfo)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.AdditionalInfo = additionalInfo;
        }

        // Metode til at printe customer info
        public void PrintCustomerDetails()
        {
            Console.WriteLine($"Name: {this.Name}"
                            + $"\nEmail: {this.Email}"
                            + $"\nPhone Number: {this.Phone}"
                            + $"\nAdditional Info: {this.AdditionalInfo}");
        }
    }
}
