using System.ComponentModel;

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
                int singleCardRes = 0;

                var gameSplit = line.Split(":");
                var winOwnSplit = gameSplit[1].Split("|");
                String winNumbs = winOwnSplit[0];
                String[] sasa = winNumbs.Split(" ");
                var ownSplit = winOwnSplit[1];
                String[] yo = ownSplit.Split(" ");
                yo = FormatNumbers(yo);
                sasa = FormatNumbers(sasa);

                foreach (string s in sasa)
                {
                    if (yo.Contains(s) && !s.Equals("") && !s.Equals(" "))
                    {
                        if (singleCardRes == 0)
                        {
                            singleCardRes = 1;
                        }
                        else
                        {
                            singleCardRes *= 2;
                        }
                    }

                }

                result += singleCardRes;


                line = sr.ReadLine();
            }

            Console.WriteLine(@$"Part 1 Result is: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
    static string[] FormatNumbers(string[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                // Parse each number, format it with at least two digits, and store it back in the array
                numbers[i] = int.Parse(numbers[i]).ToString("D2");
            }
            catch (Exception e)
            {

            }

        }

        return numbers;
    }
}