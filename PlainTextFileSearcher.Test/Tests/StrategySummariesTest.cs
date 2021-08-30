using PlainTextFileSearcher.Business.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlainTextFileSearcher.Test.Tests
{
    public class StrategySummariesTest
    {
        [Fact]
        public void EXECUTE_HEAD_OF_RETURN_VALUE_ITEM_TEST()
        {
            string path = Environment.CurrentDirectory + @"\..\..\..\UniTestFiles\+Üjpest_FC_81f1.html";
            List<string> AllLines = new List<string>();
            StrategySummaries.ExecuteHead(AllLines, path, path);
            Assert.True(AllLines.Count > 0);
        }

        [Fact]
        public void EXECUTE_BODY_OF_RETURN_VALUE_ITEM_TEST()
        {
            string textwithcoordinates = @"row: 150 col: 3 : ... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a> opgericht als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...";
            List<string> AllLines = new List<string>();
            StrategySummaries.ExecuteBody(AllLines,textwithcoordinates);
        }
    }
}
