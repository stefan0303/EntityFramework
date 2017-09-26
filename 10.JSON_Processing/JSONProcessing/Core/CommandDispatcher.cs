using JSONProcessing.Core.Commands;
using System;
using System.Linq;

namespace JSONProcessing.Core
{
    public class CommandDispatcher : IDispatcher
    {
        public string Dispatch(string[] data)
        {
            var command = data[0].ToLower();
            data = data.Skip(1).ToArray();
            var result = string.Empty;

            switch (command)
            {
                case "query":
                    var queryCommand = new QueryCommand(data);
                    result = queryCommand.Execute();
                    break;
                case "clear":
                case "cls":
                    Console.Clear();
                    break;
                case "exit":
                    new ExitCommand().Execute();
                    break;

                default:
                    throw new ArgumentException("Invalid command!");
            }

            return result;
        }
    }
}
