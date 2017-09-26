using JSONProcessing.Common.Properties;
using Newtonsoft.Json;
using System;
using System.IO;

namespace JSONProcessing.Common
{
    public static class Exporter
    {
        public static void Export(IExportable source, string fileTitle = null)
        {
            if (fileTitle == null)
                fileTitle = source.GetType().Name;

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var serializer = JsonSerializer.CreateDefault();
            var filePath = Resources.exportPath + $"{fileTitle}_{timestamp}.json";

            using (var sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, source.ExportData);
            }
        }
    }
}