using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace W3cLogParser
{
    public class W3CLogFilesParser<T> : IW3CLogParser<T> where T : new()
    {
        private readonly IReadOnlyDictionary<string, string> _entityMappings;
        public W3CLogFilesParser(IReadOnlyDictionary<string, string> entityMappings)
        {
            _entityMappings = entityMappings;
        }

        public async Task<IEnumerable<T>> ParseAsync(string filePath)
        {
            var fileFields = filePath.GetLogFileFields(_entityMappings);
            using (var streamReader = new StreamReader(filePath))
            {
                var list = new List<T>();
                while (true)
                {
                    var line = await streamReader.ReadLineAsync();
                    if (line == null) break;
                    if (line.StartsWith("#")) continue;
                    list.Add(line.ToLogEntry<T>(fileFields));
                }
                return list;
            }
        }

        public IEnumerable<T> Parse(string filePath)
        {
            var fileFields = filePath.GetLogFileFields(_entityMappings);
            using (var streamReader = new StreamReader(filePath))
            {
                while (true)
                {
                    var line = streamReader.ReadLine();
                    if (line == null) break;
                    if (line.StartsWith("#")) continue;
                    yield return line.ToLogEntry<T>(fileFields);
                }
            }
        }
    }
}
