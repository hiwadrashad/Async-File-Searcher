using PlainTextFileSearcher.Business.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlainTextFileSearcher.Test.Tests
{
    public class SubRoutinesTest
    {
        [Fact]
        public void SPLIT_LINE_TEST()
        { 
           string Line = @"row: 150 col: 3 : ... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a> opgericht als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...";
           string word = "opgericht";
           string[] splitted = SubRoutines.SplitLine(Line, word);
           Assert.True(splitted.Count() > 0);
            
        }

        [Fact]
        public void ADD_TO_CONCENTRIC_LIST_TEST()
        {
            string Line = @"row: 150 col: 3 : ... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a> opgericht als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...";
            string word = "opgericht";
            int index = 0;
            string[] splitted = SubRoutines.SplitLine(Line, word);
            List<string> RightLine = new List<string>();
            List<string> LeftLine = new List<string>();
            SubRoutines.AddToConcentricList(index, splitted, RightLine, LeftLine);
            Assert.True(RightLine.Count > 0 || LeftLine.Count > 0);
        }

        [Fact]
        public void COMBINE_LEFT_AND_RIGHT_LIST()
        {
            int combineindex = 0;
            List<(string, string)> combinedLines = new List<(string, string)>();
            List<string> LeftLine = new List<string>() { "row: 150 col: 3 : ... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a> " };
            List<string> RightLine = new List<string>() { " als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>..." };
            SubRoutines.CombineLeftAndRightList(combineindex, combinedLines, LeftLine, RightLine);
            Assert.True(combinedLines.Count() > 0);
        }

        [Fact]
        public void RETURN_TEXT_WITH_COORDINATES()
        {
            (string, string) fullparagraph = (" ... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a>", "als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...");
            string word = "Voorbeeld";
            int row = 100;
            string Line = "... club werd in <a href='.. / .. / .. / .. / articles / 1 / 8 / 8 / 1885.html' title='1885'>1885</a>" + "Voorbeeld" + "als <i>Újpesti Torna Egylet</i> en is daarmee de oudste van het land. De<p>...";
            string value = SubRoutines.ReturnTextWithCoordinates(fullparagraph,word,row,Line);
            Assert.True(!String.IsNullOrEmpty(value));
        }
    }
}
