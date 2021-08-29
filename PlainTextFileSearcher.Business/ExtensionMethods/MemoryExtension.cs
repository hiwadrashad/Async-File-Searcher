using System;
using System.Collections.Generic;
using System.Text;

namespace PlainTextFileSearcher.Business.ExtensionMethods
{
    public static class MemoryExtension
    {

        public static Memory<T> Add<T>(this ref Memory<T> MemoryStruct, T ValueToAdd) where T : class
        {
            T[] MemoryArray = MemoryStruct.ToArray();
            int NewSize = MemoryArray.Length + 1;
            Array.Resize<T>(ref MemoryArray, NewSize);
            MemoryArray[NewSize - 1] = ValueToAdd;
            MemoryStruct = new Memory<T>(MemoryArray);
            return MemoryStruct;
        }

        public static IEnumerable<T> MemoryGetForeach<T>(this Memory<T> memory) where T : class
        {
            T[] MemoryArray = memory.ToArray();
            foreach (var value in MemoryArray)
            {
                yield return value;
            }
        }

    }
}
