class Part1
{
    public static void Result()
    {
        string[] allLines;
        long result = 0;
        List<Dictionary<long, long>> allConversions = new List<Dictionary<long, long>>();

        try
        {
            allLines = File.ReadAllLines("./input.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;
        }

        int startLine = 2;
        Dictionary<long, long> mappings = new Dictionary<long, long>();
        List<int> seeds = new List<int>();
        foreach (String line in allLines)
        {
            Console.WriteLine(line);
            int index = Array.IndexOf(allLines, line);
            if (String.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (index < startLine)
            {
                if (index == 0)
                {
                    //Reading Seeds
                    String[] seedSplit = line.Split(":");
                    String[] allSeeds = seedSplit[1].Split(" ");
                    foreach (string seed in allSeeds)
                    {
                        try
                        {
                            seeds.Add(int.Parse(seed));
                        }
                        catch (Exception e)
                        {

                        }

                    }
                }
                continue;
            }

            if (line.Contains("map"))
            {
                //Add the dictonary before to the list and create a new dictonary
                if (mappings.Count > 0)
                {
                    allConversions.Add(mappings);
                }
                mappings = new Dictionary<long, long>();
                Console.WriteLine("Map: " + line);
                continue;
            }

            String[] lineSplit = line.Split(" ");
            long rsltStart = long.Parse(lineSplit[0]);
            long srcStart = long.Parse(lineSplit[1]);
            long range = long.Parse(lineSplit[2]);

            for (long x = srcStart; x < srcStart + range; x++)
            {
                mappings.Add(x, rsltStart);
                rsltStart++;
            }
            Console.WriteLine("One line finished!");
        }


        allConversions.Add(mappings);
        Console.WriteLine($"All mappings are done! In total there are {allConversions.Count}");

        foreach (long seed in seeds)
        {
            long res = seed;
            foreach (var dic in allConversions)
            {
                if (dic.TryGetValue(res, out long foundValue))
                {
                    res = foundValue;
                }
            }

            if (result == 0)
            {
                result = res;
            }
            if (res < result)
            {
                result = res;
            }
        }

        Console.WriteLine($"The lowest Location is: {result}");
    }
}