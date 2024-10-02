using WordFinder;
using System.Diagnostics;
internal class Program
{
    private static void Main(string[] args)
    {
        List<string> listForMatrix = new List<string>();
        listForMatrix.Add("abcdc");
        listForMatrix.Add("fgwio");
        listForMatrix.Add("chill");
        listForMatrix.Add("pqnsd");
        listForMatrix.Add("uvdxy");
        WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

        List<string> listForSearch = new List<string>();
        listForSearch.Add("cold");
        listForSearch.Add("wind");
        listForSearch.Add("snow");
        listForSearch.Add("chill");

        var resultList=wf.Find(listForSearch);

        Console.WriteLine("Top Ten most found words");
        foreach (string foundWord in resultList)
        {
            Console.WriteLine("Word: " + foundWord);
        }
        Console.ReadKey();
    }
}