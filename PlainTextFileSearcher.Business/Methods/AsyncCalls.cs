using PlainTextFileSearcher.Business.Interfaces;
using PlainTextFileSearcher.Business.Singletons;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlainTextFileSearcher.Business.ExtensionMethods;
using PlainTextFileSearcher.Business.Types;

namespace PlainTextFileSearcher.Business.Methods
{
    public class AsyncCalls
    {
        public static Task<ConcurrentList<string>> GetLinesAsync(string item)
        {
            Task<ConcurrentList<string>> GetLinesAsync = new Task<ConcurrentList<string>>(() => File.ReadAllLines(item).ToList().ToConcurrentList<string>(), CancelationTokenSingleton.GetCancelationToken());
            if (CancelationTokenSingleton.GetCancelationToken().IsCancellationRequested)
            {
                return GetLinesAsync;
            }
            GetLinesAsync.Start();
            return GetLinesAsync;
        }

        public static Task<bool> ContainsWordAsync(string Line, string word)
        {
            Task<bool> ContainsWordAsync = new Task<bool>(() => Line.Contains(word), CancelationTokenSingleton.GetCancelationToken());
            if (CancelationTokenSingleton.GetCancelationToken().IsCancellationRequested)
            {
                return ContainsWordAsync;
            }
            ContainsWordAsync.Start();
            return ContainsWordAsync;
        }

        public static Task<ConcurrentList<string>> GetFilesAsync(string path)
        {
            Task<ConcurrentList<string>> GetFilesAsync = new Task<ConcurrentList<string>>(() => Directory.GetFiles(path, "*.*", searchOption: SearchOption.AllDirectories).Where(a => a.EndsWith(".txt") || a.EndsWith(".html")).ToList().ToConcurrentList<string>(), CancelationTokenSingleton.GetCancelationToken());
            if (CancelationTokenSingleton.GetCancelationToken().IsCancellationRequested)
            {
                return GetFilesAsync;
            }
            GetFilesAsync.Start();
            return GetFilesAsync;
        }

    }
}
