using System;
using System.Security.Cryptography.X509Certificates;
using Genspil;

class Program
{

    static void Main(string[] args)
    {
        Storage gameStorage = new Storage();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the 'GenSpil' app!");
            Console.WriteLine("1. View list of games.");
            Console.WriteLine("2. Administer Games.");
            Console.WriteLine("3. Make Inquiry.");
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

                    gameStorage.PrintAllGames(gameStorage.Games);

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
                                    gameStorage.FilterGameByName(nameOrder);
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
                                    gameStorage.FilterGameByCondition(conditionOrder);
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
                                    gameStorage.FilterGameByPrice(priceOrder);
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
                                    gameStorage.FilterGameByMinPlayer(minPlayerOrder);
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
                                    gameStorage.FilterGameByMinPlayer(maxPlayerOrder);
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
                                    gameStorage.FilterGameByGenre(genreOrder);
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
                    gameStorage.PrintAllGames(gameStorage.Games);
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
                                gameStorage.AddGame();
                                adminRunning = false;
                                break;

                            case 2:
                                gameStorage.RemoveGame();
                                adminRunning = false;
                                break;

                            case 0:
                                adminRunning = false;
                                break;

                        }

                    }
                    break;
                case 3:
                    // Opret forespørgsel
                   
                    
                    break; 
                case 4:
                    gameStorage.SearchGameByName();
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
    

