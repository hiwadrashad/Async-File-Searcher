using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Interfaces
{
    public interface IAsyncCalls
    {
        Task<ConcurrentList<string>> GetLinesAsync(string item);
        Task<bool> ContainsWordAsync(string Line, string word);
        Task<ConcurrentList<string>> GetFilesAsync(string path);
    }
}
