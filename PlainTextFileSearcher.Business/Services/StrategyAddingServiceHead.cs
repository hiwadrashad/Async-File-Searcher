using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlainTextFileSearcher.Business.ExtensionMethods;
using PlainTextFileSearcher.Business.Interfaces;
using PlainTextFileSearcher.Business.Singletons;
using PlainTextFileSearcher.Business.Types;

namespace PlainTextFileSearcher.Business.Services
{
    public class StrategyAddingServiceHead : IStrategyAddingService
    {
        public void AddBody(ConcurrentList<string> AllLines, string textwithcoordinates)
        {
            //throw new NotImplementedException();
        }

        public void AddHeader(ConcurrentList<string> AllLines, string item, string path)
        {
            AllLines.Add("");
            AllLines.Add(item.Remove(0, path.Length));
            Singletons.ResultsSingleton.AddResult("");
            Singletons.ResultsSingleton.AddResult(item.Remove(0, path.Length));
        }
    }
}
