class Part2
{
    public static void Result()
    {
        String[] allLines;
        try
        {
            allLines = File.ReadAllLines("./input.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to read file input!");
            return;
        }

        String[] timeSplit = allLines[0].Split(":");
        String[] disSplit = allLines[1].Split(":");
        long time = long.Parse(timeSplit[1].Replace(" ", ""));
        long distance = long.Parse(disSplit[1].Replace(" ", ""));

        int result = 0;
        for (int x = 1; x < time; x++)
        {
            long travelDistance = x * (time - x);
            if (travelDistance >= distance)
            {
                result++;
            }
        }
        Console.WriteLine($"Result of Part 2: {result}");
    }
}