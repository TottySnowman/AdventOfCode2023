class Part1
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

        List<string> allTimes = timeSplit[1].Split(" ").ToList();
        List<string> allDis = disSplit[1].Split(" ").ToList();
        int result = 1;
        for (int i = 0; i < allTimes.Count; i++)
        {
            int validCounter = 0;
            int time = int.Parse(allTimes[i]);
            int distance = int.Parse(allDis[i]);

            for (int x = 1; x < time; x++)
            {
                int travelDistance = x * (time - x);
                if (travelDistance > distance)
                {
                    validCounter++;
                }
            }
            result *= validCounter;
        }
        Console.WriteLine($"Result of Part 1: {result}");
    }
}