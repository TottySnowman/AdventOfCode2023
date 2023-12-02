class Part1
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
                //12 red cubes, 13 green cubes, and 14 blue cubes
                String replacedLine = line.Replace(";", ",");
                String[] split = replacedLine.Split(":");
                String[] cubes = split[1].Split(",");
                Boolean valid = true;
                foreach (string cube in cubes)
                {
                    int cubeAmount = int.Parse(new string(cube.Where(c => char.IsDigit(c)).ToArray()));
                    if (cube.Contains("blue") && cubeAmount > 14)
                    {

                        valid = false;
                        break;
                    }
                    else if (cube.Contains("red") && cubeAmount > 12)
                    {

                        valid = false;
                        break;
                    }
                    else if (cube.Contains("green") && cubeAmount > 13)
                    {

                        valid = false;
                        break;
                    }
                }
                String[] gameSplit = split[0].Split(" ");
                if (valid)
                {
                    result += int.Parse(gameSplit[1].ToString());
                }
                line = sr.ReadLine();

            }
            sr.Close();
            Console.WriteLine($"The final result of Part 1 is: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}