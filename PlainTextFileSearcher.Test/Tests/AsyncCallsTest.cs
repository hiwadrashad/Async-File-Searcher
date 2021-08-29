using PlainTextFileSearcher.Business.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlainTextFileSearcher.Test.Tests
{
    public class AsyncCallsTest
    {
        [Fact]
        public async void GET_LINES_FROM_FILES_ASYNC_TEST()
        { 
            string path = Environment.CurrentDirectory + @"\..\..\..\UniTestFiles\+Üjpest_FC_81f1.html";
            List<string> Lines = await AsyncCalls.GetLinesAsync(path);
            Assert.True(Lines.Count > 0);
        }

        [Fact]
        public async void CONTAINS_WORD_ASYNC_TEST()
        {
            string line = "MOCKING DATA TEST PARAGRAPH";
            string word = "DATA";
            bool ContainsWord = await AsyncCalls.ContainsWordAsync(line,word);
            Assert.True(ContainsWord);
        }

        [Fact]
        public async void GET_FILES_ASYNC_TEST()
        {
            string path = Environment.CurrentDirectory + @"\..\..\..";
            List<string> Files = await AsyncCalls.GetFilesAsync(path);
            Assert.True(Files.Count() > 0);
        }
    }
}
