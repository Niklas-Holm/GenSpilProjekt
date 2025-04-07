namespace Genspil
{
    public class Inquiry
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public Customer Customer { get; set; }

        private static List<int> usedIds = new List<int>();
        private static Random _random = new Random();

        public Inquiry(string gameName, Customer customer)
        {
            this.Id = GenerateUniqueId();
            this.GameName = gameName;
            this.Customer = customer;
        }

        public Inquiry(int id, string gameName, Customer customer)
        {
            this.Id = id;
            this.GameName = gameName;
            this.Customer = customer;
        }

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

        public void PrintInquiryDetails()
        {
            Console.WriteLine($"Id: {this.Id}"
                            + $"\nGame Name: {this.GameName}"
                            + $"\n\nCustomer Details");
            Console.WriteLine(new string('-', 12));
            this.Customer.PrintCustomerDetails();
        }

        public override string ToString()
        {
            return $"{Id},{GameName},{Customer.Name},{Customer.Email},{Customer.Phone},{Customer.AdditionalInfo}";
        }

        public static Inquiry FromString(string data)
        {
            var parts = data.Split(',');

            int id = int.Parse(parts[0]);
            string gameName = parts[1];
            string name = parts[2];
            string email = parts[3];
            int phone = int.Parse(parts[4]);
            string additionalInfo = parts[5];

            var customer = new Customer(name, email, phone, additionalInfo);
            return new Inquiry(id, gameName, customer);
        }
    }
}
