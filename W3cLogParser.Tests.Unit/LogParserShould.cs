using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace W3cLogParser.Tests.Unit
{
    [TestClass]
    public class LogParserShould
    {
        private readonly IW3CLogParser<LogEntry> _parser;
        private const string DirectoryPath = @"C:\Temp\log";
        public LogParserShould()
        {
            //TODO: copy some of the IIS log files to location C:\Temp\log

            //Create a property mapper for LogEntry
            var entityMapper = new W3CEntityMapper<LogEntry>()
                .Map(e => e.ClientIp, W3CFileds.ClientIpAddress)
                .Map(e => e.Date, W3CFileds.Date)
                .Map(e => e.Time, W3CFileds.Time)
                .Map(e => e.Method, W3CFileds.Method)
                .Map(e => e.Port, W3CFileds.ServerPort);

            //create new instance of LogFileParser with the above mappings provided
            _parser = new W3CLogFilesParser<LogEntry>(entityMapper.GetMappings());
        }

        [TestMethod]
        public async Task ParseW3CLogFilesAsync()
        {
            var allFiles = Directory.EnumerateFileSystemEntries(DirectoryPath);
            foreach (var file in allFiles)
            {
                var entires = await _parser.ParseAsync(Path.Combine(DirectoryPath, file));
                Assert.IsTrue(entires.Any());
            }
        }

        [TestMethod]
        public void ParseW3CLogFiles()
        {
            var allFiles = Directory.EnumerateFileSystemEntries(DirectoryPath);
            foreach (var file in allFiles)
            {
                var entires = _parser.Parse(Path.Combine(DirectoryPath, file));
                Assert.IsTrue(entires.Any());
            }
        }
    }
}
