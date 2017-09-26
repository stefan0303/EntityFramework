using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JSONProcessing.Common
{
    public static class Importer<T> where T : class
    {
        public static IEnumerable<T> Import()
        {
            throw new NotImplementedException();
        }

        public static T[] ImportFromJSON(string filePath = null, string fileName = null)
        {

            if (fileName == null)
            {
                fileName = typeof(T).Name.Replace("Dto", "");
            }

            if (filePath == null)
            {
                filePath = Properties.Resources.importPath;
            }

            var files = Directory.GetFiles(Properties.Resources.importPath);
            var target = files
                .Where(f => f.EndsWith(".json"))
                .Select(f => new { e = f.Split('/').Last() })
                .Select(f => f.e.Remove(f.e.LastIndexOf('.')));

            fileName = target
                .FirstOrDefault(f =>
                    f.Equals(fileName, StringComparison.OrdinalIgnoreCase)
                    || f.Equals(fileName + "s", StringComparison.OrdinalIgnoreCase)
                    || f.Equals(fileName.Remove(fileName.Length - 1) + "ies", StringComparison.OrdinalIgnoreCase));

            if (filePath == null)
            {
                throw new ArgumentNullException($"File not found in {filePath}!");
            }

            var data = File.ReadAllLines(filePath + fileName + ".json");

            return JsonConvert.DeserializeObject<T[]>(string.Join("", data));
        }
    }
}
