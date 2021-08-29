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
        void FullParagraphExpressionIterator(Expression<Func<(string, string), string, int, string, string>> ReturnTextWithCoordinates, string word, int row, string Line, List<(string, string)> combinedlines, ref Memory<string> AllLines);
        void FullParagraphIterator(List<(string, string)> combinedlines, string word, int row, string Line, ref Memory<string> AllLines);
        void SplitExpressionIterator(Expression<Action<int, string[], List<string>, List<string>>> AddToConcentricList, string[] splitted, int index, List<string> RightLine, List<string> LeftLine);
        void SplitIterator(string[] splitted, int index, List<string> RightLine, List<string> LeftLine);
        void LineIterator(List<string> Lines, string word, int row, int AmountOfFoundLines, int nodeindex, int AmountOfFoundFiles, ref Memory<string> AllLines, string item, string path);
        void AllFilesIterator(List<string> AllFiles, string word, int AmoutnOfFoundLines, ref Memory<string> AllLines, string path, int AmountOfFoundLines);
    }
}
