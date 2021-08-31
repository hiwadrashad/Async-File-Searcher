using PlainTextFileSearcher.Business.Singletons;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Winforms.ClassExtensions
{
    public class FormExtension
    {
        private void AssignValueToLabel(Form1 form)
        {
            ConcurrentBag<string> LabelValues = new ConcurrentBag<string>();
            for (int i = 0; i > 5; i++)
            {
                Thread.Sleep(500);
                LabelValues.Except(ResultsSingleton.GetResults());
                //this.tbxSearchResults.Text = string.Join(Environment.NewLine, LabelValues.ToArray());

            }
        }
    }
}
