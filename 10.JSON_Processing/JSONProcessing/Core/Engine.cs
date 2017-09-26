using System;

namespace JSONProcessing.Core
{
    public static class Engine
    {
        private static readonly CommandDispatcher CommandDispatcher;

        static Engine()
        {
            CommandDispatcher = new CommandDispatcher();
        }

        public static void Run()
        {
            while (true)
            {
                Console.BufferHeight = 1000;
                //try
                //{
                    Console.WriteLine("Available commands: clear(cls), exit, query (1-10) - eg. query 2");
                    string[] input = Console.ReadLine().Trim().Split();
                    string result = CommandDispatcher.Dispatch(input);
                    Console.WriteLine(result);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Oops something went wrong!");
                //    Console.WriteLine(e.Message);
                //}
            }
        }
    }
}
