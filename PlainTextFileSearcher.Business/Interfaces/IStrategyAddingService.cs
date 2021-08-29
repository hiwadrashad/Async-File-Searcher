using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Interfaces
{
    public interface IStrategyAddingService
    {
       void AddHeader(ref Memory<string> AllLines, string item, string path);
       void AddBody(ref Memory<string> AllLines, string textwithcoordinates);
    }
}
