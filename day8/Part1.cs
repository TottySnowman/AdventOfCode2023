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
            Console.WriteLine("Failed to read input!");
            return;
        }

        String stepPattern = allLines[0];

        Dictionary<string, string[]> steps = new Dictionary<string, string[]>();
        bool reachedDestination = false;
        foreach (string line in allLines.Skip(2))
        {
            string[] stepSplit = line.Split("=");
            steps[stepSplit[0].Trim()] = stepSplit[1].Replace("(", "").Replace(")", "").Split(",").Select(x => x.Trim()).ToArray();
        }

        if (!steps.TryGetValue("AAA", out var values))
        {
            Console.WriteLine($"Step AAA was not found!");
            return;
        }

        var singleStep = stepPattern[0].ToString();
        string currStepValue = getStepValue(values, singleStep);

        int step = 1;
        int stepIndex = 1;
        while (!reachedDestination)
        {
            try
            {
                singleStep = stepPattern[stepIndex].ToString();
            }
            catch (Exception ex)
            {
                singleStep = stepPattern[0].ToString();
                stepIndex = 0;
            }

            if (!steps.TryGetValue(currStepValue, out values))
            {
                Console.WriteLine($"Error! Failed to find a value: {currStepValue}");
                return;
            };

            currStepValue = getStepValue(values, singleStep);
            step++;
            if (currStepValue.Equals("ZZZ"))
            {
                reachedDestination = true;
            }
            stepIndex++;
        }

        Console.WriteLine($"Result of Part 1: {step}");
    }

    static string getStepValue(string[] step, string direction)
    {
        if (direction.Equals("L"))
        {
            return step[0];
        }
        else
        {
            return step[1];
        }
    }
}