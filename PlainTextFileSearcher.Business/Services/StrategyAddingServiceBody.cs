using PlainTextFileSearcher.Business.Singletons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlainTextFileSearcher.Business.ExtensionMethods;
using PlainTextFileSearcher.Business.Interfaces;

namespace PlainTextFileSearcher.Business.Services
{
    public class StrategyAddingServiceBody : IStrategyAddingService
    {
        public void AddBody(ref Memory<string> AllLines, string textwithcoordinates)
        {
            AllLines.Add(textwithcoordinates);
        }

        public void AddHeader(ref Memory<string> AllLines, string item, string path)
        {
            throw new NotImplementedException();
        }
    }
}
