using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Types
{
    public class Infinite
    {
        public static IEnumerable<bool> ReturnInfinite()
        {
            while (true)
            {
                yield return true;
            }
        }
    }
}
