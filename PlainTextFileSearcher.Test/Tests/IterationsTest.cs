using PlainTextFileSearcher.Business.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlainTextFileSearcher.Test.Tests
{
    public class IterationsTest
    {
        [Fact]
        public void FULL_PARAGRAPH_ITERATOR_TEST()
        {
            int row = 100;
            string Line = "... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a>" + "Voorbeeld" + "als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...";
            List<(string, string)> combinedLines = new List<(string, string)>() {("... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a>" + "Voorbeeld", "als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...") };
            string word = "Voorbeeld";
            List<string> AllLines = new List<string>();
            Iterations.FullParagraphIterator(combinedLines,word,row,Line,AllLines);
            Assert.True(AllLines.Count > 0);
        }

        [Fact]
        public void SPLIT_ITERATOR_TEST()
        {
            string Line = "... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a>" + "Voorbeeld" + "als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...";
            string word = "Voorbeeld";
            string[] splitted = SubRoutines.SplitLine(Line,word);
            int index = 0;
            List<string> LeftLine = new List<string>();
            List<string> RightLine = new List<string>();
            Iterations.SplitIterator(splitted,index,RightLine,LeftLine);
            Assert.True(RightLine.Count() > 0 || LeftLine.Count > 0);
        }
        [Fact]
        public void ALL_FILES_ITERATOR()
        {
            List<string> AllFiles = new List<string>() 
            { Environment.CurrentDirectory + @"\..\..\..\UniTestFiles\+Üjpest_FC_81f1.html" };
            string word = "DOCTYPE";
            int AmoutnOfFoundLines = 0;
            List<string> AllLines = new List<string>();
            string path =  Environment.CurrentDirectory + @"\..\..\..\UniTestFiles\+Üjpest_FC_81f1.html";
            int AmountOfFoundLines = 0;
            Iterations.AllFilesIterator(AllFiles,word,AmoutnOfFoundLines,AllLines,path,AmountOfFoundLines);
            Assert.True(AllLines.Count > 0);
        }
    }
}
