using PlainTextFileSearcher.Business.Singletons;
using PlainTextFileSearcher.Business.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlainTextFileSearcher.Business.Methods
{
    public class SubRoutines
    {
        public async static Task<string[]> SplitLineAsync(string Line, string word)
        {
            Task<string[]> Split = new Task<string[]>(() => SplitLine(Line,word), CancelationTokenSingleton.GetCancelationToken());
            Split.Start();
            return await Split;
        }
        public static string[] SplitLine(string Line, string word)
        {
            var occurancesofword = Regex.Matches(Line, word).Count;
            var splitted = Line.Split(word, occurancesofword + 1);
            return splitted;
        }

        public async static Task AddToConcentricListAsync(int index, string[] splitted, ConcurrentList<string> RightLine, ConcurrentList<string> LeftLine)
        {

            Task AddConcentric = new Task(() => AddToConcentricList(index,splitted,RightLine,LeftLine), CancelationTokenSingleton.GetCancelationToken());
            AddConcentric.Start();
            await AddConcentric;
        }

        public static void AddToConcentricList(int index, string[] splitted, ConcurrentList<string> RightLine, ConcurrentList<string>LeftLine)
        {

            if (index % 2 == 0)
            {
                if (splitted[index].Length > 20)
                {
                    splitted[index] = splitted[index].Substring(0, 20);
                    RightLine.Add(splitted[index]);
                }
                else
                {
                    RightLine.Add(splitted[index]);
                }
            }
            if (index % 2 != 0)
            {
                if (splitted[index].Length > 20)
                {
                    splitted[index] = splitted[index].Substring(Math.Max(0, splitted[index].Length - 20));
                    LeftLine.Add(splitted[index]);
                }
                else
                {
                    LeftLine.Add(splitted[index]);

                }
            }
        }

        public static async Task CombineLeftAndRightListAsync(int combineindex, ConcurrentList<(string, string)> combinedlines, ConcurrentList<string> LeftLine, ConcurrentList<string> RightLine)
        {

            Task Combined = new Task(() => CombineLeftAndRightList(combineindex, combinedlines, LeftLine, RightLine), CancelationTokenSingleton.GetCancelationToken());
            Combined.Start();
            await Combined;
        }

        public static void CombineLeftAndRightList(int combineindex, ConcurrentList<(string,string)> combinedlines, ConcurrentList<string> LeftLine, ConcurrentList<string> RightLine)
        {
            if (combineindex == 0)
            {
                if (LeftLine.Count == 0 && RightLine.Count == 0)
                {
                    combinedlines.Add(("", ""));
                }
                else
                if (LeftLine.Count == 0)
                {
                    combinedlines.Add(("", RightLine[combineindex]));

                }
                else
                if (RightLine.Count == 0)
                {
                    combinedlines.Add((LeftLine[combineindex], ""));

                }
                else
                {
                    combinedlines.Add((LeftLine[combineindex], RightLine[combineindex]));

                }
            }
            else
            if (combineindex == LeftLine.Count - 1)
            {
                combinedlines.Add((LeftLine[combineindex - 1], RightLine[combineindex]));
            }
            else
            {
                combinedlines.Add((RightLine[combineindex], LeftLine[combineindex]));
            }
        }

        public async static Task<string> ReturnTextWithCoordinatesAsync((string, string) fullparagraph, string word, int row, string Line)
        {
            Task<string> TextWithCoordinates = new Task<string>(() => ReturnTextWithCoordinates(fullparagraph,word,row,Line), CancelationTokenSingleton.GetCancelationToken());
            TextWithCoordinates.Start();
            return await TextWithCoordinates;
        }

        public static string ReturnTextWithCoordinates((string,string) fullparagraph, string word, int row, string Line)
        {
            var text = fullparagraph.Item1 + word + fullparagraph.Item2;
            text = " : ..." + text + "...";
            var textwithcoordinates = "row: " + row + " col: " + Line.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) + text;
            return textwithcoordinates;
        }

        public static void RemoveEmptyHeaders(ConcurrentList<string> AllLines)
        {
            int index = 0;
            foreach (var item in AllLines)
            {
                if (!String.IsNullOrEmpty(AllLines[index]))
                {
                    if (String.IsNullOrEmpty(AllLines[index - 1]))
                    {
                        if (AllLines.ElementAtOrDefault(index + 1) == null)
                        {

                        }
                        else
                        {
                            if (String.IsNullOrEmpty(AllLines[index + 1])) ;
                            {
                                AllLines.RemoveAt(index);
                            }
                        }
                    }
                 
                }
                
            }
        }
    }
}
