using System.Collections.Concurrent;

namespace WordFinder
{
    public class WordFinder : IWordFinder
    {

        readonly string[] lines;

        public WordFinder(IEnumerable<string> matrix)
        {
            string[] horizontals;
            string[] verticals;


            horizontals = matrix.ToArray();
            verticals = new string[horizontals[0].Length];
            for (int n = 0; n < verticals.Length; n++)
            {
                verticals[n] = GetVertical(n, horizontals);// assumes all the strings have the same length
            }


            lines = horizontals.Concat(verticals).ToArray();
        }

        public IEnumerable<string> FindAll(IEnumerable<string> wordstream)
        {
            HashSet<string> result = new HashSet<string>(); //uses a hashset to avoid duplicate results
            foreach (string word in wordstream)
            {
                if (lines.Any(l => l.Contains(word)))
                {
                    result.Add(word);
                }
            }
            return result;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
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

        public IEnumerable<string> ParallelFindAll(IEnumerable<string> wordstream)
        {
            ConcurrentBag<string> result = []; //cannot use a hashset because it's not thread safe.

            Parallel.ForEach(wordstream, word =>
            {
                if (lines.Any(l => l.Contains(word)))
                {
                    result.Add(word);
                }
            }
            );

            return result;
        }

        public IEnumerable<string> ParallelFind(IEnumerable<string> wordstream)
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

        private static string GetVertical(int index, string[] horizontals)
        {
            string result = string.Empty;
            foreach (string s in horizontals)
            {
                result += s[index];// this will fail if not all the horizontal strings have the same length
            }
            return result;
        }

        private static int CountTotalAppearances(string word, string[] lines)
        {
            return lines.Sum(x => CountAppearances(word, x));
        }

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
