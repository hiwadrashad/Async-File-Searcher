using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PlainTextFileSearcher.Business.Methods
{
    public class SubRoutines
    {
        public static string[] SplitLine(string Line, string word)
        {
            var occurancesofword = Regex.Matches(Line, word).Count;
            var splitted = Line.Split(word, occurancesofword + 1);
            return splitted;
        }

        public static void AddToConcentricList(int index, string[] splitted, List<string> RightLine,List<string>LeftLine)
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
                splitted[index] = splitted[index].Substring(Math.Max(0, splitted.Length - 20));
                LeftLine.Add(splitted[index]);
            }
        }

        public static void CombineLeftAndRightList(int combineindex, List<(string,string)> combinedlines, List<string> LeftLine, List<string> RightLine)
        {
            if (combineindex == 0)
            {

                combinedlines.Add((LeftLine[combineindex], RightLine[combineindex]));
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

        public static string ReturnTextWithCoordinates((string,string) fullparagraph, string word, int row, string Line)
        {
            var text = fullparagraph.Item1 + word + fullparagraph.Item2;
            text = " : ..." + text + "...";
            var textwithcoordinates = "row: " + row + " col: " + Line.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) + text;
            return textwithcoordinates;
        }
    }
}
