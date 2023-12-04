using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;


class DigitPosition
{
    public int Digit { get; set; }
    public int StartPosition { get; set; }
    public Boolean SpecialChar { get; set; }

    public int EndPosition => StartPosition + Digit.ToString().Length;
}
class Part1
{
    public static int result = 0;
    public static void Result()
    {
        String line;
        String sPrevLine = "";
        String sNextLine = "";
        StreamReader sr = new StreamReader("./input.txt");
        //Read the first line of text
        line = sr.ReadLine();
        while (line != null)
        {
            var nextList = new List<DigitPosition>();
            try
            {
                sNextLine = sr.ReadLine();
                nextList = getParsedList(sNextLine, false);
            }
            catch (Exception ex)
            {
                sNextLine = "";
            }

            var currentList = getParsedList(line, true);

            var prevList = getParsedList(sPrevLine, false);

            for (int x = 0; x < currentList.Count; x++)
            {
                var currentDigit = currentList[x];

                for (int i = 0; i < prevList.Count; i++)
                {
                    if (prevList[i].StartPosition == currentDigit.StartPosition || prevList[i].StartPosition == (currentDigit.StartPosition + currentDigit.Digit.ToString().Length) || IsInBetween(currentDigit, prevList[i]))
                    {
                        if (prevList[i].SpecialChar)
                        {
                            result += currentDigit.Digit;
                            Console.WriteLine("Added " + currentDigit.Digit + " to Result!");
                            currentDigit.Digit = 0;
                        }

                    }
                }

                for (int y = 0; y < nextList.Count; y++)
                {
                    if (nextList[y].StartPosition == currentDigit.StartPosition || nextList[y].StartPosition == currentDigit.EndPosition + 1 || IsInBetween(currentDigit, nextList[y]))
                    {
                        if (nextList[y].SpecialChar)
                        {
                            result += currentDigit.Digit;
                            Console.WriteLine("Added " + currentDigit.Digit + " to Result!");
                        }

                    }
                }
            }
            sPrevLine = line;
            if (sNextLine.Equals(""))
            {
                break;
            }
            line = sNextLine;

        }
        Console.WriteLine("The Result of Part 1 is: " + result);
    }

    private static bool IsInBetween(DigitPosition first, DigitPosition second)
    {
        // Calculate end position of the first item
        int endPosition = first.EndPosition;

        // Check if the start position of the second item is within the range of the first item
        return second.StartPosition + 1 >= first.StartPosition && second.StartPosition <= endPosition + 1;
    }
    private static List<DigitPosition> getParsedList(string line, Boolean current)
    {
        List<DigitPosition> positions = new List<DigitPosition>();
        line = line.Replace("-", "+");
        line = line.Replace(".", "a");

        char[] singleChar = line.ToCharArray();
        string singleNumb = "";

        for (int x = 0; x < singleChar.Length; x++)
        {
            if (char.IsDigit(singleChar[x]))
            {
                singleNumb += singleChar[x];
            }
            else if (!char.IsLetterOrDigit(singleChar[x]))
            {
                positions.Add(new DigitPosition
                {
                    Digit = 0,
                    StartPosition = x - singleNumb.Length,
                    SpecialChar = true
                });
                if (!singleNumb.Equals("") && current)
                {
                    result += int.Parse(singleNumb);
                    Console.WriteLine("Added" + singleNumb + " to Result!");
                }
                singleNumb = "";
            }
            else if (!singleNumb.Equals(""))
            {
                positions.Add(new DigitPosition
                {
                    Digit = int.Parse(singleNumb),
                    StartPosition = x - singleNumb.Length
                });
                singleNumb = "";
            }
        }

        return positions;
    }
}