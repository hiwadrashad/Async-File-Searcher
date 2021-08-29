using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Methods
{
    public class Iterations
    {
        public static void FullParagraphExpressionIterator(Expression<Func<(string, string), string, int, string,string>> ReturnTextWithCoordinates,  string word, int row, string Line, List<(string, string)> combinedlines, ref Memory<string> AllLines)
        {
            foreach (var fullparagraph in combinedlines)
            {
                var textwithcoordinates = ReturnTextWithCoordinates.Compile()?.Invoke(fullparagraph, word, row, Line);
                StrategySummaries.ExecuteBody(ref AllLines, textwithcoordinates);
            }
        }

        public static void FullParagraphIterator(List<(string,string)> combinedlines, string word,int row,string Line,ref Memory<string> AllLines)
        {
            foreach (var fullparagraph in combinedlines)
            {
                var textwithcoordinates = SubRoutines.ReturnTextWithCoordinates(fullparagraph, word, row, Line);
                StrategySummaries.ExecuteBody(ref AllLines, textwithcoordinates);
            }
        }

        public static void SplitExpressionIterator(Expression<Action<int,string[],List<string>,List<string>>> AddToConcentricList,string[] splitted, int index,List<string> RightLine,List<string> LeftLine)
        {
            foreach (var split in splitted)
            {
                AddToConcentricList.Compile()?.Invoke(index,splitted,RightLine,LeftLine);
                index++;
            }
        }

        public static void SplitIterator(string[] splitted, int index,List<string> RightLine, List<string> LeftLine)
        {
            foreach (var split in splitted)
            {
                SubRoutines.AddToConcentricList(index, splitted, RightLine, LeftLine);
                index++;
            }
        }

        public static void LineIterator(List<string> Lines,string word, int row,int AmountOfFoundLines,int nodeindex,int AmountOfFoundFiles,ref Memory<string> AllLines,string item,string path)
        {
            foreach (var Line in Lines)
            {
                var ContainsWordAsync = AsyncCalls.ContainsWordAsync(Line, word);
                row++;
                if (ContainsWordAsync.Result)
                {
                    AmountOfFoundLines++;
                    nodeindex++;
                    if (nodeindex == 1)
                    {
                        AmountOfFoundFiles++;
                        StrategySummaries.ExecuteHead(ref AllLines, item, path);
                    }

                    var splitted = SubRoutines.SplitLine(Line, word);
                    int index = 0;
                    List<string> LeftLine = new List<string>();
                    List<string> RightLine = new List<string>();
                    Iterations.SplitIterator(splitted, index, RightLine, LeftLine);
                    List<(string, string)> combinedlines = new List<(string, string)>();
                    int combineindex = 0;

                    SubRoutines.CombineLeftAndRightList(combineindex, combinedlines, LeftLine, RightLine);
                    Iterations.FullParagraphIterator(combinedlines, word, row, Line, ref AllLines);

                }
            }
        }

        public static void AllFilesIterator(List<string> AllFiles,string word,int AmoutnOfFoundLines,ref Memory<string> AllLines, string path, int AmountOfFoundLines)
        {
            foreach (var item in AllFiles)
            {
                int row = 0;
                int nodeindex = 0;
                List<string> Lines = PlainTextFileSearcher.Business.Methods.AsyncCalls.GetLinesAsync(item).Result;
                Iterations.LineIterator(Lines, word, row, AmountOfFoundLines, nodeindex, AmountOfFoundLines, ref AllLines, item, path);

            }
        }



    }

}

