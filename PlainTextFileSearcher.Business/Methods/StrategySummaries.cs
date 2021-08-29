using PlainTextFileSearcher.Business.DesignPatterns;
using PlainTextFileSearcher.Business.Services;
using PlainTextFileSearcher.Business.Singletons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainTextFileSearcher.Business.Methods
{
    public class StrategySummaries
    {
        public static void ExecuteHead(ref Memory<string> AllLines, string item, string path)
        {
            Strategy SINGLETON = StrategySingleton.GetStrategy();
            SINGLETON.SetStrategy(new StrategyAddingServiceHead());
            SINGLETON.ExecuteHeader(ref AllLines, item, path);
        }

        public static void ExecuteBody(ref Memory<string> AllLines,string textwithcoordinates)
        {
            Strategy SINGLETON = StrategySingleton.GetStrategy();
            SINGLETON.SetStrategy(new StrategyAddingServiceBody());
            SINGLETON.ExecuteBody(ref AllLines, textwithcoordinates);
        }
    }
}
