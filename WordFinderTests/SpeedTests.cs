using RandomString4Net;
using WordFinder;

namespace WordFinderTests
{
    public class SpeedTests
    {


        public readonly IEnumerable<string> _FullRandomMatrix;
        public readonly IEnumerable<string> _RandomWordStream_10000;
        public readonly IEnumerable<string> _RandomWordStream_100000;
        public readonly IEnumerable<string> _RandomWordStream_1000000;
        public readonly IWordFinder _WordFinder;

        public SpeedTests()
        {
            _FullRandomMatrix = CreateRandomMatrix(64, 64);
            _RandomWordStream_10000 = CreateRandomWordsStream(10000);
            _RandomWordStream_100000 = CreateRandomWordsStream(100000);
            _RandomWordStream_1000000 = CreateRandomWordsStream(1000000);
            _WordFinder = new WordFinder.WordFinder(_FullRandomMatrix);
        }

        private IEnumerable<string> CreateRandomMatrix(int rows, int columns)
        {
            List<string> matrix = [.. RandomString.GetStrings(Types.ALPHABET_LOWERCASE, rows, columns)];
            return matrix;
        }

        private IEnumerable<string> CreateRandomWordsStream(int words)
        {
            return RandomString.GetStrings(Types.ALPHABET_LOWERCASE, words, 4);
        }
        [Fact]
        public void Test_FullMatrix_10000_words_sequential()
        {
            var result = _WordFinder.Find_Sequential(_RandomWordStream_10000);
        }

        [Fact]
        public void Test_FullMatrix_100000_words_sequential()
        {
            var result = _WordFinder.Find_Sequential(_RandomWordStream_100000);
        }

        [Fact]
        public void Test_FullMatrix_1000000_words_sequential()
        {
            var result = _WordFinder.Find_Sequential(_RandomWordStream_1000000);
        }

        [Fact]
        public void Test_FullMatrix_10000_words_parallel()
        {
            var result = _WordFinder.Find(_RandomWordStream_10000);
        }

        [Fact]
        public void Test_FullMatrix_100000_words_parallel()
        {
            var result = _WordFinder.Find(_RandomWordStream_100000);
        }

        [Fact]
        public void Test_FullMatrix_1000000_words_parallel()
        {
            var result = _WordFinder.Find(_RandomWordStream_1000000);
        }
    }
}
