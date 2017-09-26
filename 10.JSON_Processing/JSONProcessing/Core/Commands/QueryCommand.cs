namespace JSONProcessing.Core.Commands
{
    class QueryCommand : IExecutable<string>
    {
        private readonly string[] _data;
        public QueryCommand(string[] data)
        {
            _data = data;
        }
        public string Execute()
        {
            return new QueryDispatcher().Dispatch(_data);
        }
    }
}
