using PlainTextFileSearcher.Business.Types;
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
        void AddToConcentricList(int index, string[] splitted, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine);
        void CombineLeftAndRightList(int combineindex, ConcurrentList<(string, string)> combinedlines, ConcurrentList<string> LeftLine, ConcurrentList<string> RightLine);
        string ReturnTextWithCoordinates((string, string) fullparagraph, string word, int row, string Line);
    }
}
