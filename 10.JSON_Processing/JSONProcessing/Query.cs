using JSONProcessing.Common;
using System.Collections.Generic;

namespace JSONProcessing
{
    public abstract class Query : IExecutable<string>, IExportable
    {
        public abstract string Execute();
        public abstract void Export();

        public virtual IEnumerable<object> ExportData { get; set; }
    }
}
