class Part1
{
    public static void Result()
    {
        string[] allLines;
        try
        {
            allLines = File.ReadAllLines("input.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        var allInput = allLines[0].Split(",").ToArray();
        int result = 0;

        foreach (var input in allInput)
        {
            result += Calculate(input);
        }


        Console.WriteLine($"Result of Part 1: {result}");
    }

    private static int Calculate(string input)
    {
        int result = 0;
        var singleChars = input.ToCharArray();
        foreach (var ch in singleChars)
        {
            result += ch;
            result *= 17;
            result %= 256;
        }
        return result;
    }
}