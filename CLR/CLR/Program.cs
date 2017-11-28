using System;
using CLR.Commands;

namespace CLR
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            var usersCommands = new Application();

            while (true)
            {
                Console.WriteLine("Input command:");
                var command = Console.ReadLine();
                usersCommands.RunCommand(command);

            }
        }
    }
}

