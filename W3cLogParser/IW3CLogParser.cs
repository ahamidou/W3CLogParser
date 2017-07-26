using System.Collections.Generic;
using System.Threading.Tasks;

namespace W3cLogParser
{
    public interface IW3CLogParser<T>
    {
        Task<IEnumerable<T>> ParseAsync(string filePath);
        IEnumerable<T> Parse(string filePath);
    }
}