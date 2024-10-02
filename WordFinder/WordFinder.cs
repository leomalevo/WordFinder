using System.Collections.Concurrent;

namespace WordFinder
{
    public class WordFinder
    {
        private Matrix _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = new Matrix(matrix);
        }

        /// <summary>
        /// Method that will find all the words in wordstream
        /// - The repeated words are not searched
        /// - This will return the top ten of the most found words
        /// - If no word is found, it will return a empty stream
        /// </summary>
        /// <param name="wordstream"></param>
        /// <returns></returns>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            // collection for concurrent threads
            var results = new ConcurrentBag<WordSearchResult>();

            // search word by word (if it has repeated words, they are not searched again)
            Parallel.ForEach(wordstream.Distinct(), wordToSearch =>
            {
                    int count = 0;
                    //search on matrix´s horizontal streams
                    for(int i=0;i<_matrix.Rows;i++)
                    {
                        if (_matrix.GetRow(i).Contains(wordToSearch))
                        {
                            count++;
                        }

                    }

                    //search on matrix´s vertical streams
                    for (int i = 0; i < _matrix.Columns; i++)
                    {
                        if (_matrix.GetColumn(i).Contains(wordToSearch))
                        {
                            count++;
                        }
                    }
                //saves word and ocurrences
                results.Add(new WordSearchResult(count, wordToSearch));
            });

            //returns top 10 most found words (excluding not found)
            //return results.OrderByDescending(x => x.Count).Where(x => x.Count > 0).Select(x => x.Word).Take(10);
            return results.OrderByDescending(x => x.Count).ThenBy(x => x.Word).Where(x => x.Count > 0).Select(x => x.Word).Take(10);
         
        }
    }
}
