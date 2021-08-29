using PlainTextFileSearcher.Business.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainTextFileSearcher.Business.Singletons
{
    public class StrategySingleton
    {
        private static Strategy _STRATEGY;

        private StrategySingleton()
        {

        }

        public static Strategy GetStrategy()
        {
            if (_STRATEGY == null)
            {
                _STRATEGY = new Strategy();
            }

            return _STRATEGY;
        }

    }
}
