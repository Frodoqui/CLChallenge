namespace WordFinderTests
{
    public class WordFinderTests
    {


        [Fact]
        public void Test_Sample_Case()
        {
            // Setup
            var words = new string[4] { "chill", "cold", "wind", "snow" };
            var matrix = new string[5] {
             "abcdc",
             "rgwio",
             "chill",
             "pqnsd",
             "uvdxy"
            };

            IEnumerable<string> expectedResults = ["chill", "cold", "wind"];

            WordFinder.WordFinder wordFinder = new(matrix);

            // Act
            var actualResults = wordFinder.Find(words);

            // Assert
            Assert.Equivalent(expectedResults, actualResults, true);

        }

        [Fact]
        public void Repeated_Word_Is_Returned_Only_Once()
        {
            // Setup
            var words = new string[5] { "chill", "cold", "wind", "snow", "chill" };
            var matrix = new string[5] {
             "abcdc",
             "rgwio",
             "chill",
             "pqnsd",
             "uvdxy"
            };

            IEnumerable<string> expectedResults = ["chill", "cold", "wind"];

            WordFinder.WordFinder wordFinder = new(matrix);

            // Act
            var actualResults = wordFinder.Find(words);

            // Assert
            Assert.Equivalent(expectedResults, actualResults, true);

        }

        [Fact]
        public void No_Matches_Returns_Empty_Set()
        {
            // Setup
            var words = new string[4] { "warm", "hot", "still", "snow" };
            var matrix = new string[5] {
             "abcdc",
             "rgwio",
             "chill",
             "pqnsd",
             "uvdxy"
            };

            IEnumerable<string> expectedResults = [];

            WordFinder.WordFinder wordFinder = new(matrix);

            // Act
            var actualResults = wordFinder.Find(words);

            // Assert
            Assert.Equivalent(expectedResults, actualResults, true);

        }

        [Fact]
        public void Only_Top_10_Repeated_Matches_Returned()
        {
            // Setup
            var words = new string[15] { "chill", "cold", "wind", "freeze", "storm", "blizzard", "winter", "cloud", "sled", "sky", "ice", "rain", "drizzle", "water", "snow" }         ;
            var matrix = new string[20]  {
                 "coldorgwioqnsdfreeze",
                 "orgwiowindasdadsadff",
                 "lchillcnquertyabcdef",
                 "dpqnsdndstormkjhgdce",
                 "auvdxycoldfblizzardf",
                 "winteraaaarkjhgfbnmv",
                 "skyrainvvgepojhervnx",
                 "cdbaktrewsesledookul",
                 "asksjkwefczraintrrik",
                 "hhdlfreezeegetymnsog",
                 "dqlearbodduuppchilld",
                 "arbdwintesporgcloudd",
                 "windireegtconvfufaze",
                 "tfeenrepzojoljfreeze",
                 "bardtaeezrwinteredzg",
                 "relfeieezmmofdfagere",
                 "edcvrnefrecoldthmjdt",
                 "drmkjhgfdspoiuuytrew",
                 "sledffrgfghcjlkfhjkz",
                 "blizzardwinterskyice",
                 };

            IEnumerable<string> expectedResults = [
            "wind","freeze","cold","winter","sled","rain","blizzard","sky","chill","storm",
            ];

            WordFinder.WordFinder wordFinder = new(matrix);

            // Act
            var actualResults = wordFinder.Find(words);

            Assert.Equivalent(expectedResults, actualResults, true);

        }



       

    }
}