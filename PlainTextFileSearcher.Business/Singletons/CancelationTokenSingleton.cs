using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PlainTextFileSearcher.Business.Singletons
{
    public class CancelationTokenSingleton
    {
        private static CancellationToken _TOKEN;

        private static CancellationTokenSource _CTS;

        private CancelationTokenSingleton()
        {
        }

        public static CancellationTokenSource GetCancellationTokenSource()
        {
            if (_CTS == null)
            {
                _CTS = new CancellationTokenSource();
            }

            return _CTS;
        }

        public static CancellationToken GetCancelationToken()
        {
            if (_CTS == null)
            {
                _CTS = new CancellationTokenSource();
            }
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (_TOKEN == null)
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                _TOKEN = _CTS.Token;
            }
            return _TOKEN;
        }


    }
}
