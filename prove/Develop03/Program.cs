using System;

namespace Develop03
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string scriptureText = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

            Scripture scripture = new Scripture(reference, scriptureText);

            while (true)
            {
                Console.Clear();

                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Excellent work! You have memorized the passage.");
                    break;
                }

                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3);
            }
        }
    }
}