using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.ExtensionMethods
{
    public static class ConcurrentBagExtension
    {
        public static ConcurrentBag<T> ToConcurrentBag<T>(this List<T> source) where T : class
        {
            var ConcurrentSource = new ConcurrentBag<T>(source);
            return ConcurrentSource;
        }

        public static ConcurrentList<T> ToConcurrentList<T>(this List<T> source) where T : class 
        {
            var concurrentSource = new ConcurrentList<T>(source);
            return concurrentSource;
        }

    }
}
