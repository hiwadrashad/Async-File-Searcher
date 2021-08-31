using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Singletons
{
    public class ResultsSingleton
    {
        private static ConcurrentList<string> _results;
        private static int _currentFileCount;

        private ResultsSingleton()
        {

        }

        public static ConcurrentList<string> GetResults()
        {
            return _results;
        }

        public static int GetCurrentFileCount()
        {
            return _currentFileCount;
        }

        public static void AssignCurrentFileCount(int input)
        {
            _currentFileCount = input;
        }

        public static void AddResult(string input)
        {
            if (_results == null)
            {
                _results = new ConcurrentList<string>();
            }
            _results.Add(input);
        }

    }
}
