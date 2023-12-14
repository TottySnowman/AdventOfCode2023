class Part1
{
    public static void Result()
    {
        string[] allLines;

        try
        {
            allLines = File.ReadAllLines("./input.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Couldn't read File");
            Console.WriteLine(ex.Message);
            return;
        }

        var grid = new string[allLines.Length, allLines[0].Length];
        for (int x = 0; x < allLines.Length; x++)
        {
            var vals = allLines[x].ToCharArray();
            for (int y = 0; y < vals.Length; y++)
            {
                grid[x, y] = vals[y].ToString();
            }
        }

        int stoneCount, startIndex, result = 0;

        for (int x = 0; x < allLines[0].Length; x++)
        {
            stoneCount = 0;
            startIndex = 0;
            for (int y = 0; y < allLines.Length; y++)
            {
                if (grid[y, x].Equals("#"))
                {
                    result += CalculateResult(startIndex, stoneCount, allLines.Length);
                    startIndex = y + 1;
                    stoneCount = 0;
                }
                else if (grid[y, x].Equals("O"))
                {
                    stoneCount++;
                }
            }
            //Add Stones
            result += CalculateResult(startIndex, stoneCount, allLines.Length);
        }

        Console.WriteLine($"Result of Part 1: {result}");
    }

    private static int CalculateResult(int startIndex, int stoneCount, int maxLength)
    {
        int res = 0;
        int starting = maxLength - startIndex;

        for (int x = 0; x < stoneCount; x++)
        {
            res += starting;
            starting--;
        }
        return res;
    }
}