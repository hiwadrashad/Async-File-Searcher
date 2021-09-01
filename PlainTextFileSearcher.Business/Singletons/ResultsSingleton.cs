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
        private static ConcurrentList<string> _results = new ConcurrentList<string>();
        private static int _currentFileCount;
        private static int _currentFoundFiles;
        private static int _currentFoundLines;

        private ResultsSingleton()
        {

        }

        public static ConcurrentList<string> GetResults()
        {
            return _results;
        }

        public static void AssignCurrentFoundFiles()
        {
            var incremented = _currentFoundFiles + 1;
            _currentFoundFiles = incremented;
        }

        public static int GetCurrentFoundFiles()
        {
            return _currentFoundFiles;    
        }

        public static void AssignCurrentFoundLines()
        {
            var incremented = _currentFoundLines + 1;
            _currentFoundLines = incremented;
        }

        public static int GetCurrentFoundLines()
        {
            return _currentFoundLines;
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
