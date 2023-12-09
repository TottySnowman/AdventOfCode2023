class Part1
{
    public static void Result()
    {
        List<string> allLines;

        try
        {
            allLines = File.ReadAllLines("./input.txt").ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to read lines of file!");
            return;
        }

        List<CardSet> preparedList = new List<CardSet>();
        foreach (string line in allLines)
        {
            string[] split = line.Split(" ");
            preparedList.Add(new CardSet()
            {
                Cards = split[0],
                BetAmout = int.Parse(split[1])
            });
        }
        preparedList.Sort(CompareStrength);
        for (int x = 0; x < preparedList.Count; x++)
        {
            preparedList[x].BetAmout = preparedList[x].BetAmout * (x + 1);
        }
        Console.WriteLine($"The Sum of Part 1 is: {preparedList.Sum(cardSet => cardSet.BetAmout)}");

    }
    private static int CompareStrength(CardSet x, CardSet y)
    {
        string[] rankings = { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
        var typeX = getType(x.Cards);
        var typeY = getType(y.Cards);

        if (typeX > typeY)
        {
            return 1;
        }
        if (typeY > typeX)
        {
            return -1;
        }

        // They have the same type
        for (int index = 0; index < x.Cards.Length; index++)
        {
            if (x.Cards[index].Equals(y.Cards[index]))
            {
                continue;
            }
            for (int i = 0; i < rankings.Length; i++)
            {
                string currX = x.Cards[index].ToString();
                string currR = rankings[i];
                string currY = y.Cards[index].ToString();
                if (currX.Equals(currR))
                {
                    return 1;
                }
                else if (currY.Equals(currR))
                {
                    return -1;
                }
            }
        }
        return 0;
    }

    private static double getType(String cards)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>();

        // Count occurrences of each character
        foreach (char x in cards)
        {
            if (counts.ContainsKey(x))
            {
                counts[x]++;
            }
            else
            {
                counts[x] = 1;
            }
        }

        // Get sorted list of counts
        List<int> amounts = counts.Values.ToList();
        amounts.Sort();

        // Check for different cases
        if (amounts.SequenceEqual(new List<int> { 5 }))
        {
            return 5;
        }
        if (amounts.SequenceEqual(new List<int> { 1, 4 }))
        {
            return 4;
        }
        if (amounts.SequenceEqual(new List<int> { 2, 3 }))
        {
            return 3.5;
        }
        if (amounts.SequenceEqual(new List<int> { 1, 1, 3 }))
        {
            return 3;
        }
        if (amounts.SequenceEqual(new List<int> { 1, 2, 2 }))
        {
            return 2.5;
        }
        if (amounts.SequenceEqual(new List<int> { 1, 1, 1, 2 }))
        {
            return 2;
        }

        return 1;
    }
}

class CardSet
{
    public String Cards { set; get; }
    public int BetAmout { set; get; }
}