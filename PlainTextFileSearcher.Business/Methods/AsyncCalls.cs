using PlainTextFileSearcher.Business.Interfaces;
using PlainTextFileSearcher.Business.Singletons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PlainTextFileSearcher.Business.Methods
{
    public class AsyncCalls
    {
        public static Task<List<string>> GetLinesAsync(string item)
        {
            Task<List<string>> GetLinesAsync = new Task<List<string>>(() => File.ReadAllLines(item).ToList(), CancelationTokenSingleton.GetCancelationToken());
            GetLinesAsync.Start();
            return GetLinesAsync;
        }

        public static Task<bool> ContainsWordAsync(string Line, string word)
        {
            Task<bool> ContainsWordAsync = new Task<bool>(() => Line.Contains(word), CancelationTokenSingleton.GetCancelationToken());
            ContainsWordAsync.Start();
            return ContainsWordAsync;
        }

        public static Task<List<string>> GetFilesAsync(string path)
        {
            Task<List<string>> GetFilesAsync = new Task<List<string>>(() => Directory.GetFiles(path, "*.*", searchOption: SearchOption.AllDirectories).Where(a => a.EndsWith(".txt") || a.EndsWith(".html")).ToList(), CancelationTokenSingleton.GetCancelationToken());
            GetFilesAsync.Start();
            return GetFilesAsync;
        }

    }
}
