using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Part1
{
    public static void Result()
    {
        string[] allLines;
        int result = 0;
        try
        {
            allLines = File.ReadAllLines("./input.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to read the input!");
            return;
        }

        foreach (string line in allLines)
        {
            List<int> numbers = line.Split(' ')
                        .Select(int.Parse)
                        .ToList();
            numbers.Reverse();
            List<List<int>> allNumbs = new List<List<int>>();
            allNumbs.Add(numbers);
            var results = recursive(allNumbs);

            results.Reverse();

            for (int x = 1; x < results.Count - 1; x++)
            {
                int lastItem = results[x].Last();
                int nextItem = results[x + 1].First();
                results[x + 1].Add(lastItem + nextItem);
            }

            result += results.Last().Last();
        }

        Console.WriteLine($"Result of Part 1: {result}");
    }

    private static List<List<int>> recursive(List<List<int>> numbers)
    {
        List<int> differences = new List<int>();
        var lastList = numbers.Last();
        for (int x = 0; x < lastList.Count - 1; x++)
        {
            differences.Add(lastList[x] - lastList[x + 1]);
        }
        numbers.Add(differences);
        if (differences.Sum() != 0)
        {
            return recursive(numbers);
        }
        return numbers;
    }
}