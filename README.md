# WordFinder
Notes about WordFinder
-	The code was commented to make it more readable and understandable. 
-	I used a char[,] for the matrix because all words will have same length. In case of different lengths a jagged array van be a better approach for the solution.
-	In the Find() method I have used Parallel.Foreach in order to optimize the searching.  A ConcurrentBag was used too for handle the items in concurrent manner in the result collection.
-	For finding the words I have used the method String.Contains() instead of IndexOf() because of the readability and performance, avoiding extra check on IndexOf result.
-	I also added an extra Test Project in order to test all the acceptance criteria points described for the challenge.

