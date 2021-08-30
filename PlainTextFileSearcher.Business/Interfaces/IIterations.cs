using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Interfaces
{
    public interface IIterations
    {
        void FullParagraphExpressionIterator(Expression<Func<(string, string), string, int, string, string>> ReturnTextWithCoordinates, string word, int row, string Line, ConcurrentList<(string, string)> combinedlines,ConcurrentList<string> AllLines);
        void FullParagraphIterator(ConcurrentList<(string, string)> combinedlines, string word, int row, string Line, ConcurrentList<string> AllLines);
        void SplitExpressionIterator(Expression<Action<int, string[], ConcurrentList<string>, ConcurrentList<string>>> AddToConcentricList, string[] splitted, int index, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine);
        void SplitIterator(string[] splitted, int index, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine);
        void LineIterator(ConcurrentList<string> Lines, string word, int row, int AmountOfFoundLines, int nodeindex, int AmountOfFoundFiles, ConcurrentList<string> AllLines, string item, string path);
        void AllFilesIterator(ConcurrentList<string> AllFiles, string word, int AmoutnOfFoundLines, ConcurrentList<string> AllLines, string path, int AmountOfFoundLines);
    }
}
