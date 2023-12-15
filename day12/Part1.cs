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

    }
}