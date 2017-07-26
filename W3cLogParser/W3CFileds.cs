namespace W3cLogParser
{
    /// <summary>
    /// Microsoft Reference Doc: https://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/676400bc-8969-4aa7-851a-9319490a9bbb.mspx?mfr=true
    /// </summary>
    public class W3CFileds
    {
        /// <summary>
        /// Date : The date on which the activity occurred.
        /// </summary>
        public const string Date = "date";

        /// <summary>
        /// The time, in coordinated universal time (UTC), at which the activity occurred.
        /// </summary>
        public const string Time = "time";

        /// <summary>
        /// The IP address of the client that made the request.
        /// </summary>
        public const string ClientIpAddress = "c-ip";

        /// <summary>
        /// The name of the authenticated user who accessed your server. Anonymous users are indicated by a hyphen.
        /// </summary>
        public const string UserName = "cs-username";

        /// <summary>
        /// The Internet service name and instance number that was running on the client.
        /// </summary>
        public const string ServiceNameAndInstanceNumber = "s-sitename";

        /// <summary>
        /// The name of the server on which the log file entry was generated.
        /// </summary>
        public const string ServerName = "s-computername";

        /// <summary>
        /// The IP address of the server on which the log file entry was generated.
        /// </summary>
        public const string ServerIpAddress = "s-ip";

        /// <summary>
        /// The server port number that is configured for the service.
        /// </summary>
        public const string ServerPort = "s-port";

        /// <summary>
        /// The requested action, for example, a GET method.
        /// </summary>
        public const string Method = "cs-method";

        /// <summary>
        /// The target of the action, for example, Default.htm.
        /// </summary>
        public const string UriStem = "cs-uri-stem";

        /// <summary>
        /// The query, if any, that the client was trying to perform. A Universal Resource Identifier (URI) query is necessary only for dynamic pages.
        /// </summary>
        public const string UriQuery = "cs-uri-query";

        /// <summary>
        /// The HTTP status code.
        /// </summary>
        public const string HttpStatus = "sc-status";

        /// <summary>
        /// The Windows status code.
        /// </summary>
        public const string Win32Status = "sc-win32-status";

        /// <summary>
        /// The number of bytes that the server sent.
        /// </summary>
        public const string BytesSent = "sc-bytes";

        /// <summary>
        /// The number of bytes that the server received.
        /// </summary>
        public const string BytesReceived = "cs-bytes";

        /// <summary>
        /// The length of time that the action took, in milliseconds.
        /// </summary>
        public const string TimeTaken = "time-taken";

        /// <summary>
        /// The protocol version —HTTP or FTP —that the client used.
        /// </summary>
        public const string ProtocolVersion = "cs-version";

        /// <summary>
        /// The host header name, if any.
        /// </summary>
        public const string Host = "cs-host";

        /// <summary>
        /// The browser type that the client used.
        /// </summary>
        public const string UserAgent = "cs(User-Agent)";
        /// <summary>
        /// The content of the cookie sent or received, if any.
        /// </summary>
        public const string Cookie = "cs(Cookie)";

        /// <summary>
        /// The site that the user last visited. This site provided a link to the current site.
        /// </summary>
        public const string Referrer = "cs(Referrer)";

        /// <summary>
        /// The substatus error code.
        /// </summary>
        public const string ProtocolSubstatus = "sc-substatus";
    }
}