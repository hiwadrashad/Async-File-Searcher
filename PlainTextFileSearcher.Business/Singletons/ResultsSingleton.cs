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

        private ResultsSingleton()
        {

        }

        public static ConcurrentList<string> GetResults()
        {
     

            return _results;
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
