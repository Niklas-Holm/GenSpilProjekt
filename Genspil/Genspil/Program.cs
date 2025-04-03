﻿using System;
using Genspil;

class Program
{
    static void Main(string[] args)
    {
        GameStorage gameStorage = new GameStorage();
        
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Velkommen til Genspil appen!");
            Console.WriteLine("1. Se liste over spil.");
            Console.WriteLine("2. Fjern spil."); //Midlertidig
            Console.WriteLine("3. Opret forespørgsel.");
            Console.WriteLine("4. Administrer spil på lager.");
            Console.WriteLine("5. Tilføj spil:"); //Midlertidig
            Console.WriteLine("6. Afslut.");
            
            Console.Write("\nHvilken funktion vil du benytte? ");

            string inputStr = Console.ReadLine();
            int input;

            if (!int.TryParse(inputStr, out input))
            {
                Console.WriteLine("Ugyldigt input. Tryk Enter for at prøve igen.");
                Console.ReadLine();
                continue;
            }

            switch (input)
            {
                case 1:
                    // Se liste over spil
                    Console.WriteLine("Her er listen over spil...");
                    gameStorage.printAllGames();
                    break;
                case 2:
                    // Søg efter specifikt spil
                    gameStorage.RemoveGame();
                    break;
                case 3:
                    // Opret forespørgsel
                    Console.WriteLine("Opretter forespørgsel...");
                    break;
                case 4:
                    // Administrer spil på lager
                    Console.WriteLine("Administrerer spil på lager...");
                    break;
                case 5:
                    gameStorage.addGame();
                    break;
                case 6:
                    // Afslut
                    Console.WriteLine("Farvel!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg. Tryk Enter for at prøve igen.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nTryk Enter for at vende tilbage til menuen.");
                Console.ReadLine();
            }
            //hej
        }
    }
}
