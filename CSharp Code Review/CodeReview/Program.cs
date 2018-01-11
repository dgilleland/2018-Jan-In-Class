using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run();
        }

        // Our "Program" is really the "heart" of our "application".
        // So, let's treat it like an object.
        // We'll use a property that holds a bunch of Salutation objects.
        public List<Salutation> Speakers { get; private set; }
        public Program()
        {
            // The job of a constructor is to make sure that all the
            // properties/fields of the object are set to "meaningful values"
            Speakers = new List<Salutation>(); // an "empty" list
            Speakers.Add(new Salutation("Welcome to Walmart!", "Thanks for shopping at Walmart!"));
            Speakers.Add(new Salutation("nuqneH!", "Qapla'!"));
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have entered a large building. Two beings stand before you.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Who do you want to speak to? Person A or B? ");
            string userInput = Console.ReadLine().ToUpper();
            while(userInput != "A" && userInput != "B")
            {
                Console.Write("Try again:");
                userInput = Console.ReadLine().ToUpper();
            }

            Console.ResetColor();
            switch(userInput)
            {
                case "A":
                    Speak(Speakers[0]);
                    break;
                case "B":
                    Speak(Speakers[1]);
                    break;
            }
        }


        private void Speak(Salutation speaker)
        {
            Console.WriteLine(speaker.Greet());
            Console.WriteLine(speaker.SayFarewell());
        }
    }
}
