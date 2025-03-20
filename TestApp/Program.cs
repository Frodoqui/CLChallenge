//WordFinder.WordFinder wordFinder = new(
//    ["abcdc",
//     "rgwio",
//     "chill",
//     "pqnsd",
//     "uvdxy"
//    ]);

WordFinder.WordFinder wordFinder = new(
    ["abcdcw",
     "rgwioi",
     "chilln",
     "pqnsdd",
     "uvdxyx"
    ]);

var results = wordFinder.Find(["chill", "cold", "wind", "snow"]);

foreach (var item in results)
{
    Console.WriteLine(item);
}
var parallelResults = wordFinder.ParallelFind(["chill", "cold", "wind", "snow"]);

foreach (var item in parallelResults)
{
    Console.WriteLine(item);
}

int CountAppearances(string substring, string source)
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