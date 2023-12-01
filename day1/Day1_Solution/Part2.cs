class Part2{
   public static void Result(){
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
        string word = "";
        string allNumbers = "";
        foreach (char character in line)
        {
            if(char.IsDigit(character)){
                word = "";
                allNumbers += character;
                continue;
            }
            word += character.ToString();
            
            if(word.Contains("one")){
                allNumbers += "1";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("two")){
                allNumbers += "2";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("three")){
                allNumbers += "3";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("four")){
                allNumbers += "4";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("five")){
                allNumbers += "5";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("six")){
                allNumbers += "6";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("seven")){
                allNumbers += "7";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("eight")){
                allNumbers += "8";
                word = word[word.Length - 1 ].ToString();
            }
            else if(word.Contains("nine")){
                allNumbers += "9";
                word = word[word.Length - 1 ].ToString();
            }
        }
        
        //string allNumbers = new string(line.Where(c => char.IsDigit(c)).ToArray());
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

    Console.WriteLine($"The final result of Part 2 is: {result}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
    }
}