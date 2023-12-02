// See https://aka.ms/new-console-template for more information

using System.IO;
using System.Runtime.CompilerServices;

class Part1
{
    public static void Result()
    {
        String line;
        try
        {
            StreamReader sr = new StreamReader("./input.txt");
            //Read the first line of text
            line = sr.ReadLine();

            int result = 0;
            //Continue to read until you reach end of file
            while (line != null)
            {
                string allNumbers = new string(line.Where(c => char.IsDigit(c)).ToArray());
                string fullNumber = allNumbers[0].ToString();
                if (allNumbers.Length >= 2)
                {
                    fullNumber += allNumbers[allNumbers.Length - 1].ToString();
                }
                else
                {
                    fullNumber += fullNumber;
                }
                result += Int32.Parse(fullNumber);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

            Console.WriteLine($"The final result of Part 1 is: {result}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}