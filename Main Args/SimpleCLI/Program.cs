using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private void Run(string[] args)
        {
            if(args.Length > 0)
            {
                switch(args[0])
                {
                    case "--help":
                        ShowHelp();
                        break;
                    case "--echo":
                        Console.WriteLine($"\t{args[1]}");
                        break;
                    case "--source":
                        Console.WriteLine("\tNot implemented...");
                        break;
                }
            }
        }

        #region Application Driver
        public void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Simple Command-Line-Interface");
            Console.WriteLine("\nSimpleCLI [--help] | [--echo message] | [--source]\n");
            Console.WriteLine($"\t{"--help",-20} Show help");
            Console.WriteLine($"\t{"--echo",-20} Display the message");
            Console.WriteLine($"\t{"--source",-20} List the source code");

            Console.ResetColor();
        }
        #endregion
    }
}
