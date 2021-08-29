using PlainTextFileSearcher.Business.Interfaces;
using PlainTextFileSearcher.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainTextFileSearcher.Business.DesignPatterns
{
    public class Strategy
    {
        private IStrategyAddingService _strategyAddingService;

        public Strategy()
        {
                
        }

        public Strategy(IStrategyAddingService strategyAddingService)
        {
            this._strategyAddingService = strategyAddingService;
        }

        public void SetStrategy(IStrategyAddingService strategy)
        {
            this._strategyAddingService = strategy;
        }

        public void ExecuteHeader(ref Memory<string> AllLines, string item, string path)
        {
            if (this._strategyAddingService is StrategyAddingServiceHead)
            {
                this._strategyAddingService.AddHeader(ref AllLines, item, path);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void ExecuteBody(ref Memory<string> AllLines, string textwithcoordinates)
        {

            if (this._strategyAddingService is StrategyAddingServiceBody)
            {
                this._strategyAddingService.AddBody(ref AllLines, textwithcoordinates);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
