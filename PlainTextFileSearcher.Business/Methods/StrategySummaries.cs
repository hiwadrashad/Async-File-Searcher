using PlainTextFileSearcher.Business.DesignPatterns;
using PlainTextFileSearcher.Business.Services;
using PlainTextFileSearcher.Business.Singletons;
using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Methods
{
    public class StrategySummaries
    {
        public async static Task ExecuteHeadAsync(ConcurrentList<string> AllLines, string item, string path)
        {
            Task Head = new Task(() => ExecuteHead(AllLines,item,path), CancelationTokenSingleton.GetCancelationToken());
            Head.Start();
            await Head;
        }

        public async static Task ExecuteBodyAsync(ConcurrentList<string> AllLines, string textwithcoordinates)
        {
            Task Body = new Task(() => ExecuteBody(AllLines,textwithcoordinates), CancelationTokenSingleton.GetCancelationToken());
            Body.Start();
            await Body;
        }
        public static void ExecuteHead(ConcurrentList<string> AllLines, string item, string path)
        {
            Strategy SINGLETON = StrategySingleton.GetStrategy();
            SINGLETON.SetStrategy(new StrategyAddingServiceHead());
            SINGLETON.ExecuteHeader(AllLines, item, path);
        }

        public static void ExecuteBody(ConcurrentList<string> AllLines,string textwithcoordinates)
        {
            Strategy SINGLETON = StrategySingleton.GetStrategy();
            SINGLETON.SetStrategy(new StrategyAddingServiceBody());
            SINGLETON.ExecuteBody(AllLines, textwithcoordinates);
        }
    }
}
