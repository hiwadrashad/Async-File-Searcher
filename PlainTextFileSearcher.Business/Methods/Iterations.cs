using PlainTextFileSearcher.Business.Singletons;
using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Methods
{
    public class Iterations 
    {
        public static void FullParagraphExpressionIterator(Expression<Func<(string, string), string, int, string,string>> ReturnTextWithCoordinates,  string word, int row, string Line, ConcurrentList<(string, string)> combinedlines, ConcurrentList<string> AllLines)
        {
            Parallel.ForEach(combinedlines,async fullparagraph =>
            {
                                var textwithcoordinates = ReturnTextWithCoordinates.Compile()?.Invoke(fullparagraph, word, row, Line);
                await StrategySummaries.ExecuteBodyAsync(AllLines, textwithcoordinates);
            });
  
        }

        public static async Task FullParagraphIteratorAsync(ConcurrentList<(string, string)> combinedlines, string word, int row, string Line, ConcurrentList<string> AllLines)
        {
            Task Paragraph = new Task(() => FullParagraphIterator(combinedlines,word,row,Line,AllLines), CancelationTokenSingleton.GetCancelationToken());
            Paragraph.Start();
            await Paragraph;

        }

        public static void FullParagraphIterator(ConcurrentList<(string,string)> combinedlines, string word,int row,string Line, ConcurrentList<string> AllLines)
        {
            Parallel.ForEach(combinedlines,async fullparagraph =>
            {
                var textwithcoordinates = await SubRoutines.ReturnTextWithCoordinatesAsync(fullparagraph, word, row, Line);
                await StrategySummaries.ExecuteBodyAsync(AllLines, textwithcoordinates);
            });
        }

        public static void SplitExpressionIterator(Expression<Action<int,string[], ConcurrentList<string>, ConcurrentList<string>>> AddToConcentricList,string[] splitted, int index, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine)
        {
            Parallel.ForEach(splitted, split =>
            {
                AddToConcentricList.Compile()?.Invoke(index, splitted, RightLine, LeftLine);
                index++;
            });
        }

        public async static Task SplitIteratorAsync(string[] splitted, int index, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine)
        {
            Task Split = new Task(() => SplitIterator(splitted,index,RightLine,LeftLine), CancelationTokenSingleton.GetCancelationToken());
            Split.Start();
            await Split;
        }

        public static void SplitIterator(string[] splitted, int index, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine)
        {
            Parallel.ForEach(splitted, split =>
            {
                SubRoutines.AddToConcentricList(index, splitted, RightLine, LeftLine);
                index++;
            });
        }

        public async static Task LineIteratorAsync(ConcurrentList<string> Lines, string word, int row, int AmountOfFoundLines, int nodeindex, int AmountOfFoundFiles, ConcurrentList<string> AllLines, string item, string path)
        {
            await Task.Factory.StartNew(() => LineIterator(Lines, word, row, AmountOfFoundLines, nodeindex, AmountOfFoundFiles, AllLines, item, path), CancelationTokenSingleton.GetCancelationToken());
        }

        public static void LineIterator(ConcurrentList<string> Lines,string word, int row,int AmountOfFoundLines,int nodeindex,int AmountOfFoundFiles, ConcurrentList<string> AllLines,string item,string path)
        {
            Parallel.ForEach(Lines,async Line =>
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
                        StrategySummaries.ExecuteHead(AllLines, item, path);
                    }

                    var splitted = await SubRoutines.SplitLineAsync(Line, word);
                    int index = 0;
                    ConcurrentList<string> LeftLine = new ConcurrentList<string>();
                    ConcurrentList<string> RightLine = new ConcurrentList<string>();
                    await Iterations.SplitIteratorAsync(splitted, index, RightLine, LeftLine);
                    ConcurrentList<(string, string)> combinedlines = new ConcurrentList<(string, string)>();
                    int combineindex = 0;
                    await SubRoutines.CombineLeftAndRightListAsync(combineindex, combinedlines, LeftLine, RightLine);
                    await Iterations.FullParagraphIteratorAsync(combinedlines, word, row, Line, AllLines);

                }
            });

        }

        public async static Task AllFilesIteratorAsync(ConcurrentList<string> AllFiles, string word, int AmoutnOfFoundLines, ConcurrentList<string> AllLines, string path, int AmountOfFoundLines)
        {
            Task Files = new Task(() => AllFilesIterator(AllFiles,word,AmoutnOfFoundLines,AllLines,path,AmountOfFoundLines), CancelationTokenSingleton.GetCancelationToken());
            Files.Start();
            await Files;
        }

        public static async void AllFilesIterator(ConcurrentList<string> AllFiles,string word,int AmoutnOfFoundLines, ConcurrentList<string> AllLines, string path, int AmountOfFoundLines)
        {

            Singletons.ResultsSingleton.AssignCurrentFileCount(0);
            foreach (var item in AllFiles)
            {
                int currentfileindex = ResultsSingleton.GetCurrentFileCount();
                int currentfileindexincremented = currentfileindex + 1;
                ResultsSingleton.AssignCurrentFileCount(currentfileindexincremented);
                int row = 0;
                int nodeindex = 0;
                ConcurrentList<string> Lines = await PlainTextFileSearcher.Business.Methods.AsyncCalls.GetLinesAsync(item);
                Iterations.LineIterator(Lines, word, row, AmountOfFoundLines, nodeindex, AmountOfFoundLines,AllLines, item, path);              
            }
        }



    }

}

