using System;
using CLR.Commands;
using TraceResultGetter;

namespace CLR
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            var usersCommands = new Application();
            var formattersFactory = new PluginsFactory();

            while (true)
            {
                Console.WriteLine("Input command:");
                var command = Console.ReadLine();
                usersCommands.RunCommand(command, formattersFactory);

            }
        }
    }
}

