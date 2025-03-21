# CLChallenge
Challenge for CL

## How I went about this task

### The simple array approach (this is the approach I used)

What I ended up doing, taking advantage that words can only be found from left to right in columns and from top to bottom in rows, is this:

1) In the constructor the received strings are processed to extract a new string for each row (going from top to bottom)
2) These strings are joined to the original column strings to form a single array, which will be the universe for our searches. This duplicates the number of strings to search, but since the maximum matrix size is expected to be 64x64 the maximum length of our search-universe array will be 128.
3) When the Find Method is called the number of appearances of each word in each element of our search-universe array is aggregated (so if the word appears once in the first element and twice in the third the result is 3) and each word that has more than 0 appearances is added to a dictionary whose key is the word and whose value is the number of appearances.
4) Finally once each word has been searched for and registered the dictionary is sorted (desc) by the number of appearances and only the top 10 results are returned.
5) This algorithm looked like a good match for parrallelization so I changed my original "foreach" loop with a Parallel.ForEach resulting in greatly improved performance (I've left the originall sequential method in the class for comparison)

### The "human way"

Initially I thought about doing this the "human" way, meaning the way one usually goes about solving these kind of puzzles, namelly: Create a 2 dimensional matrix, search it character for character and checking against the wordstream for a word that starts with that letter, then checking in the row and the column for the complete string.
I discarted that approach because:

* It's more complex than the alternative (described above)
* I can't guarantee it would be faster, in fact it would probably be slower since it has to traverse the big word stream repeteadly looking for words that start with the lettter in the matrix position. (this can be alleviated by turning the wordstream into a dictionary where the key is the initial letter, but that requires traversing and executing complex operations in the large wordstream, and only reduces the amount of words to search to those starting with the same letter, which in a really big stream can still be too many (specially knowing that words are not equally distributed allong the alphabet) )
* It will require more memory.






