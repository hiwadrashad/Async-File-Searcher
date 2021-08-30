using PlainTextFileSearcher.Business.Singletons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlainTextFileSearcher.Business.ExtensionMethods;
using PlainTextFileSearcher.Business.Interfaces;
using PlainTextFileSearcher.Business.Types;

namespace PlainTextFileSearcher.Business.Services
{
    public class StrategyAddingServiceBody : IStrategyAddingService
    {
        public void AddBody(ConcurrentList<string> AllLines, string textwithcoordinates)
        {
            AllLines.Add(textwithcoordinates);
            Singletons.ResultsSingleton.AddResult(textwithcoordinates);
        }

        public void AddHeader(ConcurrentList<string> AllLines, string item, string path)
        {
            //throw new NotImplementedException();
        }
    }
}
