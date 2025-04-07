using System;
using System.Security.Cryptography.X509Certificates;
using Genspil;

class Program
{

    static void Main(string[] args)
    {
        Storage storage = new Storage();
       
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the 'GenSpil' app!");
            Console.WriteLine("1. View list of games.");
            Console.WriteLine("2. Administer Games.");
            Console.WriteLine("3. Administer Inquiries.");
            Console.WriteLine("4. Search Game.");
            Console.WriteLine("0. Exit.");

            Console.Write("\nWhat function would you like to use? ");

            string inputStr = Console.ReadLine();
            int input;

            if (!int.TryParse(inputStr, out input))
            {
                Console.WriteLine("Invalid input. Press 'Enter' to try again.");
                Console.ReadLine();
                continue;
            }

            switch (input)
            {
                case 1:
                    // Se liste over spil
                    Console.Clear();
                    Console.WriteLine("Here's the list:\n-----------------------");

                    storage.PrintAllGames(storage.Games);

                    Console.WriteLine("\nWhat do you wish to do?\n");

                    Console.WriteLine("1. Generate Text File List.\n" +
                                      "2. Sort List.\n" +
                                      "0. Exit. ");

                    int listSubMenuInput = Int32.Parse(Console.ReadLine());

                    switch (listSubMenuInput)
                    {
                        case 1:
                            Console.WriteLine("List Generated.");
                            break;
                        case 2:
                            Console.WriteLine("How do you want to sort the list?");
                            Console.WriteLine("1. Name. \n" +
                                              "2. Condition. \n" +
                                              "3. Price.\n" +
                                              "4. Min Player. \n" +
                                              "5. Max Player. \n" +
                                              "6. Genre. \n"+
                                              "0. Exit.");
                            int filterGamesByInput = Int32.Parse(Console.ReadLine());
                            switch (filterGamesByInput)
                            {
                                case 1:
                                    Console.WriteLine("In What Order?\n" +
                                                      "1. Ascending\n" +
                                                      "2. Descending");
                                    int nameOrder = Int32.Parse(Console.ReadLine());
                                    storage.FilterGameByName(nameOrder);
                                    Console.WriteLine("Generate text file for the sorted list? (y/n): ");
                                    string generateNameTxtInput = Console.ReadLine().ToLower();
                                    switch (generateNameTxtInput)
                                    {
                                        case "y":
                                            Console.WriteLine("Generating File");
                                            break;
                                        case "n":
                                            
                                            break;
                                            
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("In What Order?\n" +
                                                      "1. Ascending\n" +
                                                      "2. Descending");
                                    int conditionOrder = Int32.Parse(Console.ReadLine());
                                    storage.FilterGameByCondition(conditionOrder);
                                    Console.WriteLine("Generate text file for the sorted list? (y/n): ");
                                    string generateConditionTxtInput = Console.ReadLine().ToLower();
                                    switch (generateConditionTxtInput)
                                    {
                                        case "y":
                                            Console.WriteLine("Generating File");
                                            break;
                                        case "n":

                                            break;
                                            
                                    }


                                    break;

                                case 3:
                                    Console.WriteLine("In What Order?\n" +
                                                      "1. Ascending\n" +
                                                      "2. Descending");
                                    int priceOrder = Int32.Parse(Console.ReadLine());
                                    storage.FilterGameByPrice(priceOrder);
                                    Console.WriteLine("Generate text file for the sorted list? (y/n): ");
                                    string generatePriceTxtInput = Console.ReadLine().ToLower();
                                    switch (generatePriceTxtInput)
                                    {
                                        case "y":
                                            Console.WriteLine("Generating File");
                                            break;
                                        case "n":

                                            break;
                                            
                                    }


                                    break;
                                case 4:
                                    Console.WriteLine("In What Order?\n" +
                                                      "1. Ascending\n" +
                                                      "2. Descending");
                                    int minPlayerOrder = Int32.Parse(Console.ReadLine());
                                    storage.FilterGameByMinPlayer(minPlayerOrder);
                                    Console.WriteLine("Generate text file for the sorted list? (y/n): ");
                                    string generateMinPlayerTxtInput = Console.ReadLine().ToLower();
                                    switch (generateMinPlayerTxtInput)
                                    {
                                        case "y":
                                            Console.WriteLine("Generating File");
                                            break;
                                        case "n":

                                            break;
                                            
                                    }


                                    break;
                                case 5:
                                    Console.WriteLine("In What Order?\n" +
                                                      "1. Ascending\n" +
                                                      "2. Descending");
                                    int maxPlayerOrder = Int32.Parse(Console.ReadLine());
                                    storage.FilterGameByMinPlayer(maxPlayerOrder);
                                    Console.WriteLine("Generate text file for the sorted list? (y/n): ");
                                    string generateMaxPlayerTxtInput = Console.ReadLine().ToLower();
                                    switch (generateMaxPlayerTxtInput)
                                    {
                                        case "y":
                                            Console.WriteLine("Generating File");
                                            break;
                                        case "n":

                                            break;
                                            
                                    }


                                    break;
                                case 6:
                                    Console.WriteLine("In What Order?\n" +
                                                      "1. Ascending\n" +
                                                      "2. Descending");
                                    int genreOrder = Int32.Parse(Console.ReadLine());
                                    storage.FilterGameByGenre(genreOrder);
                                    Console.WriteLine("Generate text file for the sorted list? (y/n): ");
                                    string generateGenreTxtInput = Console.ReadLine().ToLower();
                                    switch (generateGenreTxtInput)
                                    {
                                        case "y":
                                            Console.WriteLine("Generating File");
                                            break;
                                        case "n":

                                            break;
                                            
                                    }


                                    break;


                            }
                            break;
                    }
                    Console.WriteLine("Here's the list of games in storage.");
                    storage.PrintAllGames(storage.Games);
                    break;
                case 2:
                    bool adminRunning = true;

                    while (adminRunning)
                    {
                        Console.Clear();

                        Console.WriteLine("1. Add Game.");
                        Console.WriteLine("2. Remove Game.");
                        Console.WriteLine("0. Exit to Main Menu");
                        Console.WriteLine("\nWhat do you wish to do?");
                        string adminInputStr = Console.ReadLine();
                        int adminInput;

                        if (!int.TryParse(adminInputStr, out adminInput))
                        {
                            Console.WriteLine("Invalid input. Press 'Enter' to try again.");
                            Console.ReadLine();
                            continue;
                        }
                        switch (adminInput)
                        {
                            case 1:
                                Console.WriteLine("Input Game Details:\n");

                                Console.Write("Enter Name: ");
                                string gameName = Console.ReadLine();

                                Condition condition;
                                while (true)
                                {
                                    Console.Write("\nEnter Condition (A, B, C, D, E, F): ");
                                    string gameDetailsInput = Console.ReadLine();
                                    if (Enum.TryParse(gameDetailsInput, true, out condition) &&
                                       Enum.IsDefined(typeof(Condition), condition))
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Invalid input. Please re-enter condition.");
                                }

                                Console.Write("\nEnter Price: ");
                                double gamePrice = double.Parse(Console.ReadLine());

                                Console.Write("\nEnter Minimum Amount of Players: ");
                                int gameMinPlayer = int.Parse(Console.ReadLine());

                                Console.Write("\nEnter Maximum Amount of Players: ");
                                int gameMaxPlayer = int.Parse(Console.ReadLine());

                                Console.Write("\nEnter Genre: ");
                                string gameGenre = Console.ReadLine();

                                storage.AddGame(gameName, condition, gamePrice, gameMinPlayer, gameMaxPlayer, gameGenre);

                                Console.WriteLine("\nGame Successfully Added \\o/");

                                adminRunning = false;
                                break;

                            case 2:
                                Console.WriteLine("Input Game Id to Remove (or press 'Q' to exit)");
                                string removeGame = Console.ReadLine();
                                int removeGameInt;

                                if (removeGame.ToLower() == "q")
                                {

                                    Console.WriteLine("You exited.");
                                    return;
                                }
                                else if (Int32.TryParse(removeGame, out removeGameInt))
                                {
                                    foreach (Game game in storage.Games)
                                    {
                                        if (game.Id == removeGameInt)
                                        {
                                            storage.SearchGameById(removeGameInt);
                                            Console.WriteLine("Do you want to delete this game? (y/n)");
                                            string removeGameInput = Console.ReadLine().ToLower();
                                            switch (removeGameInput)
                                            {
                                                case "y":
                                                    Console.WriteLine("Removal Complete. Press 'Enter' to return. ");
                                                    storage.RemoveGame(game);
                                                    Console.ReadLine();

                                                    break;
                                                case "n":
                                                    Console.WriteLine("Removal Cancelled. Press 'Enter' to return.");
                                                    Console.ReadLine();
                                                    break;
                                            }
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    break;
                                }

                               
                                adminRunning = false;
                                break;

                            case 0:
                                adminRunning = false;
                                break;

                        }

                    }
                    break;
                case 3:
                    bool inquiryAdminRunning = true;

                    while (inquiryAdminRunning)
                    {
                        Console.Clear();

                        Console.WriteLine("1. Make Inquiry.");
                        Console.WriteLine("2. Remove Inquiry.");
                        Console.WriteLine("3. View Inquiry List.");
                        Console.WriteLine("0. Exit to Main Menu");
                        Console.WriteLine("\nWhat do you wish to do?");



                        int inquiryAdminInput = Int32.Parse(Console.ReadLine());

                        switch (inquiryAdminInput)
                        {
                            case 1:
                                Console.WriteLine("Input Inquiry Details\n");

                                Console.Write("Enter Game Name: ");
                                string gameName = Console.ReadLine();

                                Console.Write("Enter Customer Name: ");
                                string customerName = Console.ReadLine();

                                Console.Write("Enter Customer Email: ");
                                string customerEmail = Console.ReadLine();

                                int customerPhone;
                                while (true)
                                {
                                    Console.Write("Enter Customer Phone Number: ");
                                    string customerPhoneInput = Console.ReadLine();

                                    if (int.TryParse(customerPhoneInput, out customerPhone))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter valid number.");
                                    }

                                }
                                Console.Write("Enter Additional Info (or leave blank): ");
                                string customerAdditionalInfo = Console.ReadLine();


                                storage.AddInquiry(gameName, customerName, customerEmail, customerPhone, customerAdditionalInfo);

                                Console.WriteLine("\nInquiry Successfully Added \\o/");

                                break;
                            case 2:
                                Console.WriteLine("Input Inquiry Id to Remove (or press 'Q' to exit)");
                                string removeInquiry = Console.ReadLine();
                                int removeInquiryInt;

                                if (removeInquiry.ToLower() == "q")
                                {

                                    Console.WriteLine("You exited.");
                                    return;
                                }
                                else if (Int32.TryParse(removeInquiry, out removeInquiryInt))
                                {
                                    foreach (Inquiry inquiry in storage.Inquiries)
                                    {
                                        if (inquiry.Id == removeInquiryInt)
                                        {
                                            storage.SearchInquiryById(removeInquiryInt);
                                            Console.WriteLine("Do you want to delete this inquiry? (y/n)");
                                            string removeInquiryInput = Console.ReadLine().ToLower();
                                            switch (removeInquiryInput)
                                            {
                                                case "y":
                                                    Console.WriteLine("Removal Complete. Press 'Enter' to return. ");
                                                    storage.RemoveInquiry(inquiry);
                                                    Console.ReadLine();

                                                    break;
                                                case "n":
                                                    Console.WriteLine("Removal Cancelled. Press 'Enter' to return.");
                                                    Console.ReadLine();
                                                    break;
                                            }
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    break;
                                }


                                inquiryAdminRunning = false;
                                break;
                            case 3:
                                storage.PrintAllInquiries();
                                Console.WriteLine("\nPress Enter to return.");
                                Console.ReadLine();
                                break;
                            case 0:
                                break;
                        }
                        
                    }
                    break;
                case 4:
                    Console.WriteLine("Input Game Name");
                    string findMatchingGame = Console.ReadLine();
                    storage.SearchGameByName(findMatchingGame);
                    break;
                case 0:
                    // Afslut
                    Console.WriteLine("Bye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Press 'Enter' to try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress 'Enter' to return to main menu.");
                Console.ReadLine();
            }



        }



    }
}
    

