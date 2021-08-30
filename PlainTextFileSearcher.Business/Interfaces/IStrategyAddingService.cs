using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Interfaces
{
    public interface IStrategyAddingService
    {
       void AddHeader(ConcurrentList<string> AllLines, string item, string path);
       void AddBody(ConcurrentList<string> AllLines, string textwithcoordinates);
    }
}
