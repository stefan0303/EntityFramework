using System.Collections.Generic;

namespace JSONProcessing.Common
{
    public interface IExportable
    {
        IEnumerable<object> ExportData { get; set; }

        void Export();
    }
}