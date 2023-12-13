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
            Console.WriteLine("Could not read file!");
            Console.WriteLine(ex.Message);
            return;
        }
        List<string> newAllLines = new List<string>();
        foreach (string line in allLines)
        {
            if (!line.Contains("#"))
            {
                newAllLines.Add(line);
            }
            newAllLines.Add(line);
        }
        string[,] map = new string[newAllLines.Count, newAllLines[0].Length];
        List<Galaxy> galaxies = new List<Galaxy>();

        for (int x = 0; x < newAllLines.Count; x++)
        {
            var vals = newAllLines[x].ToCharArray();
            for (int y = 0; y < vals.Length; y++)
            {
                map[x, y] = vals[y].ToString();
            }
        }

        var newnew = new List<string>(newAllLines);
        int extraColCount = 0;
        for (int x = 0; x < newAllLines[0].Length; x++)
        {
            bool extraCol = true;
            for (int y = 0; y < newAllLines.Count; y++)
            {
                if (newAllLines[y][x].Equals('#'))
                {
                    extraCol = false;
                    break;
                }
            }
            if (extraCol)
            {
                for (int i = 0; i < newnew.Count; i++)
                {
                    newnew[i] = newnew[i].Insert(x + extraColCount, ".");
                }
                extraColCount++;
            }
        }

        for (int x = 0; x < newnew.Count; x++)
        {
            var vals = newnew[x].ToCharArray();
            for (int y = 0; y < vals.Length; y++)
            {
                if (vals[y].Equals('#'))
                {
                    galaxies.Add(new Galaxy() { X = x, Y = y });
                }
            }
        }

        int result = 0;

        for (int x = 0; x < galaxies.Count - 1; x++)
        {
            for (int y = x; y < galaxies.Count; y++)
            {
                result += ManhattanDistance(galaxies[x].Y, galaxies[y].Y, galaxies[x].X, galaxies[y].X);
            }
        }

        Console.WriteLine($"Result von Part 1: {result}");
    }

    public static int ManhattanDistance(int x1, int x2, int y1, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}

class Galaxy
{
    public int X { get; set; }
    public int Y { get; set; }
}