using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    /// <summary>
    /// Class that will contain the search result for each word
    /// </summary>
    internal class WordSearchResult
    {
        public int Count { get; set; }
        public string Word { get; set; }

        public WordSearchResult(int count, string word)
        {
            Count = count;
            Word = word;
        }
    }
}
