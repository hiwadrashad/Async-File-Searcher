using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Interfaces
{
    public interface ISubRoutines
    {
        string[] SplitLine(string Line, string word);
        void AddToConcentricList(int index, string[] splitted, List<string> RightLine, List<string> LeftLine);
        void CombineLeftAndRightList(int combineindex, List<(string, string)> combinedlines, List<string> LeftLine, List<string> RightLine);
        string ReturnTextWithCoordinates((string, string) fullparagraph, string word, int row, string Line);
    }
}
