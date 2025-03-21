using System.Collections.Concurrent;

namespace WordFinder
{
    /// <summary>
    /// Word finder class (See README.md for more details)
    /// </summary>
    public class WordFinder : IWordFinder
    {

        readonly string[] lines;

        /// <summary>
        /// Class Constructor, creates an array of all the columns in the matrix plus all the rows (created from the original "horizontal" lines)
        /// that can be used to quickly search the whole matrix for words (since the words can only be from left to right in columns and from top to botom in rows)
        /// </summary>
        /// <param name="matrix">The set of strings that form the matrix, all strings should have the same length</param>
        public WordFinder(IEnumerable<string> matrix)
        {
            string[] columns;
            string[] rows;


            columns = matrix.ToArray();
            rows = new string[columns[0].Length];
            for (int n = 0; n < rows.Length; n++)
            {
                rows[n] = GetRow(n, columns);// assumes all the strings have the same length
            }


            lines = [.. columns, .. rows];
        }

        /// <summary>
        /// Counts the appeareances of each word in the wordstream and returns the top 10 most repeated words from the word stream found in the
        /// matrix
        /// </summary>
        /// <param name="wordstream">Words to search in the matrix</param>
        /// <returns>The top 10 most repeated words from the word stream found in the matrix
        /// </returns>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            ConcurrentDictionary<string, int> result = [];
            Parallel.ForEach(wordstream, word =>
            {
                int appeareances = CountTotalAppearances(word, lines);
                if (appeareances > 0)
                {
                    result.TryAdd(word, appeareances); 
                }
            });
            var resultList = result.ToList();
            resultList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var resultWords = resultList.ConvertAll(x => x.Key);
            return resultWords.Take(10);
        }

        /// <summary>
        /// Counts the appeareances of each word in the wordstream and returns the top 10 most repeated words from the word stream found in the
        /// matrix (in a non parallel approach for comparison)
        /// </summary>
        /// <param name="wordstream">Words to search in the matrix</param>
        /// <returns>The top 10 most repeated words from the word stream found in the matrix
        /// </returns>
        public IEnumerable<string> Find_Sequential(IEnumerable<string> wordstream)
        {
            Dictionary<string, int> result = [];
            foreach (string word in wordstream)
            {
                if (!result.ContainsKey(word))
                {
                    int appeareances = CountTotalAppearances(word, lines);
                    if (appeareances > 0)
                    {
                        result.Add(word, appeareances);
                    }
                }
            }
            var resultList = result.ToList();
            resultList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var resultWords = resultList.ConvertAll(x => x.Key);
            return resultWords.Take(10);
        }


        /// <summary>
        /// Creates a row from characters in the same position for each column
        /// </summary>
        /// <param name="index">The character position</param>
        /// <param name="columns">The column list</param>
        /// <returns>The content of the row</returns>
        private static string GetRow(int index, string[] columns)
        {
            string result = string.Empty;
            foreach (string s in columns)
            {
                result += s[index];// this will fail if not all the horizontal strings have the same length
            }
            return result;
        }

        /// <summary>
        /// Counts the appearances of a string subset in a collection of strings
        /// </summary>
        /// <param name="word">The word to search for</param>
        /// <param name="lines">The strings to search</param>
        /// <returns>The number of times the word appears</returns>
        private static int CountTotalAppearances(string word, string[] lines)
        {
            return lines.Sum(x => CountAppearances(word, x));
        }


        /// <summary>
        /// Counts the appearances of a string subset in a string. 
        /// </summary>
        /// <param name="substring">The subset to search for</param>
        /// <param name="source">The string to search</param>
        /// <returns>The number of times the word appears in the string</returns>
        private static int CountAppearances(string substring, string source)
        {
            int count = 0, n = 0;

            if (substring != "")
            {
                while ((n = source.IndexOf(substring, n, StringComparison.InvariantCulture)) != -1)
                {
                    n += substring.Length;
                    ++count;
                }
            }
            return count;
        }
    }
}
