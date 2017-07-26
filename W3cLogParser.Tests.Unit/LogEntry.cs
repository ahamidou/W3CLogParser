using System;

namespace W3cLogParser.Tests.Unit
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Method { get; set; }
        public string ClientIp { get; set; }
        public int Port { get; set; }
    }
}