using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlainTextFileSearcher.Business.ExtensionMethods;
using PlainTextFileSearcher.Business.Interfaces;
using PlainTextFileSearcher.Business.Singletons;

namespace PlainTextFileSearcher.Business.Services
{
    public class StrategyAddingServiceHead : IStrategyAddingService
    {
        public void AddBody(ref Memory<string> AllLines, string textwithcoordinates)
        {
            throw new NotImplementedException();
        }

        public void AddHeader(ref Memory<string> AllLines, string item, string path)
        {
            AllLines.Add("");
            AllLines.Add(item.Remove(0, path.Length));
        }
    }
}
