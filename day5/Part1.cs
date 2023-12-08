class Part1
{
    public static void Result()
    {
        var input = File.ReadAllLines("./input.txt");

        var seeds = input[0].Split(' ').Skip(1).Select(x => long.Parse(x)).ToList();
        var maps = new List<List<(long from, long to, long adjustment)>>();
        List<(long from, long to, long adjustment)>? currmap = null;
        foreach (var line in input.Skip(2))
        {
            if (line.EndsWith(':'))
            {
                currmap = new List<(long from, long to, long adjustment)>();
                continue;
            }
            else if (line.Length == 0 && currmap != null)
            {
                maps.Add(currmap!);
                currmap = null;
                continue;
            }

            var nums = line.Split(' ').Select(x => long.Parse(x)).ToArray();
            currmap!.Add((nums[1], nums[1] + nums[2] - 1, nums[0] - nums[1]));
        }
        if (currmap != null)
            maps.Add(currmap);

        // Part 1
        var result = long.MaxValue;
        foreach (var seed in seeds)
        {
            var value = seed;
            foreach (var map in maps)
            {
                foreach (var item in map)
                {
                    if (value >= item.from && value <= item.to)
                    {
                        value += item.adjustment;
                        break;
                    }
                }
            }
            result = Math.Min(result, value);
        }

        Console.WriteLine($"The lowest Location is: {result}");
    }
}