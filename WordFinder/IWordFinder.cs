namespace WordFinder
{
    public interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
        IEnumerable<string> ParallelFind(IEnumerable<string> wordstream);
    }
}
