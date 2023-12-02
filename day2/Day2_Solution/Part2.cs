class Part2
{
    public static void Result()
    {
        String line;
        int result = 0;
        try
        {
            StreamReader sr = new StreamReader("./input.txt");
            //Read the first line of text
            line = sr.ReadLine();
            while (line != null)
            {
                String replacedLine = line.Replace(";", ",");
                String[] split = replacedLine.Split(":");
                String[] cubes = split[1].Split(",");
                int blueMax = 0;
                int redMax = 0;
                int greenMax = 0;
                foreach (string cube in cubes)
                {
                    int cubeAmount = int.Parse(new string(cube.Where(c => char.IsDigit(c)).ToArray()));
                    if (cube.Contains("blue") && cubeAmount > blueMax)
                    {
                        blueMax = cubeAmount;
                    }
                    else if (cube.Contains("red") && cubeAmount > redMax)
                    {
                        redMax = cubeAmount;
                    }
                    else if (cube.Contains("green") && cubeAmount > greenMax)
                    {
                        greenMax = cubeAmount;
                    }
                }
                line = sr.ReadLine();
                result += blueMax * redMax * greenMax;
            }
            sr.Close();
            Console.WriteLine($"The final result of Part 2 is: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}