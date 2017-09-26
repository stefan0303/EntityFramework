using System;

namespace JSONProcessing.Core.Commands
{
    class ExitCommand : IExecutable<Action>
    {

        public Action Execute()
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);

            return null;
        }
    }
}
