//This is a console executable that can be used to "human-test" the WordFinder class, see the unit tests project also.

using System.Collections.Generic;

Console.WriteLine("Test Application for the QU Challenge");
Console.WriteLine();

IEnumerable<string> words = ["chill", "cold", "wind", "snow" ];
IEnumerable<string> matrix = [ 
     "abcdc",
     "rgwio",
     "chill",
     "pqnsd",
     "uvdxy"
    ];



RunExample("Running example from challenge description...", matrix, words, true);

words = ["chill", "cold", "wind", "freeze", "storm", "blizzard", "winter", "cloud", "sled", "sky", "ice", "rain", "drizzle", "water", "snow"];
matrix = [
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
    ];

RunExample("20x20 matrix with more than 10 words", matrix, words, true);

void RunExample(string text, IEnumerable<string> matrix, IEnumerable<string> words, bool showWords)
{
    Console.WriteLine("Example");
    Console.WriteLine();
    Console.WriteLine(text);
    Console.WriteLine();
    Console.WriteLine("matrix:");
    Console.WriteLine("".PadLeft(matrix.First().Length * 2 +1, '-'));
    foreach (var line in matrix)
    {
        foreach(char c in line)
        {
            Console.Write($"|{c}");
        }
        Console.WriteLine("|");
        Console.WriteLine("".PadLeft(matrix.First().Length * 2 + 1, '-'));
    }

    if (showWords)
    {
        Console.WriteLine($"Searching for words: {string.Join(",", words)}");
    }

    WordFinder.WordFinder wordFinder = new(matrix);
    DateTime before = DateTime.Now;
    var result = wordFinder.Find(words);
    DateTime after = DateTime.Now;
    Console.WriteLine();
    Console.WriteLine($"Found at least {result.Count()} matches in {(after - before).TotalMilliseconds} milliseconds");
    Console.WriteLine("Matches:");
    foreach (var match in result)
    {
        Console.WriteLine(match);
    }
    Console.WriteLine("Press Any Key to continue");
    Console.ReadKey(true);
    Console.WriteLine();

}