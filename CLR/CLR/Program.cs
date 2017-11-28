using System;

namespace CLR
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            var usersCommands = new UsersCommands();

            while (true)
            {
                Console.WriteLine("Input command:");
                var command = Console.ReadLine();
                usersCommands.RunCommand(command);

            }
        }
    }
}

