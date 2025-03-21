namespace WordFinder
{
    public interface IWordFinder
    {
        /// <summary>
        /// Counts the appeareances of each word in the wordstream and returns the top 10 most repeated words from the word stream found in the
        /// matrix
        /// </summary>
        /// <param name="wordstream">Words to search in the matrix</param>
        /// <returns>The top 10 most repeated words from the word stream found in the matrix
        /// </returns>
        IEnumerable<string> Find(IEnumerable<string> wordstream);

        /// <summary>
        /// Counts the appeareances of each word in the wordstream and returns the top 10 most repeated words from the word stream found in the
        /// matrix (in a non parallel approach for comparison)
        /// </summary>
        /// <param name="wordstream">Words to search in the matrix</param>
        /// <returns>The top 10 most repeated words from the word stream found in the matrix
        /// </returns>
        IEnumerable<string> Find_Sequential(IEnumerable<string> wordstream);
    }
}
