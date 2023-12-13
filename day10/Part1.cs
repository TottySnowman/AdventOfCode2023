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
            Console.WriteLine("Failed to read file!");
            Console.WriteLine(ex.Message);
            return;
        }

        int answer = 1;
        Point[,] map = new Point[allLines[0].Length, allLines.Length];
        Point? startPoint = null;

        for (int y = 0; y < allLines.Length; y++)
        {
            for (int x = 0; x < allLines[0].Length; x++)
            {
                Point point = new Point(allLines[y][x], x, y);
                map[x, y] = point;
                if (point.Symbol.Equals('S'))
                {
                    startPoint = point;
                }
            }
        }
        if (startPoint == null)
        {
            Console.WriteLine("Failed to find entry point!");
            return;
        }
        bool incorrectPipesFound = false;
        do
        {
            incorrectPipesFound = false;

            // find incorrectly connected pipes (but don't remove them yet as to not influence connection count on adjacent pipes)
            for (var y = 0; y < map.GetLength(1); y++)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y].Symbol.Equals('S') || map[x, y].Symbol.Equals('.'))
                        continue;

                    var connections = 0;
                    if (y > 0 && map[x, y].north && map[x, y - 1].south)
                        connections++;
                    if (x > 0 && map[x, y].west && map[x - 1, y].east)
                        connections++;
                    if (y < map.GetLength(1) - 1 && map[x, y].south && map[x, y + 1].north)
                        connections++;
                    if (x < map.GetLength(0) - 1 && map[x, y].east && map[x + 1, y].west)
                        connections++;

                    if (connections != 2)
                    {
                        map[x, y].ScheduleToRemove();
                        incorrectPipesFound = true;
                    }
                }
            }
            // remove all unconnected pipes marked as scheduled to remove
            for (var y = 0; y < map.GetLength(1); y++)
                for (var x = 0; x < map.GetLength(0); x++)
                    map[x, y].CleanUp();

        } while (incorrectPipesFound);

        var paths = new Position[] {
    new Position(){
        X = startPoint.X,
        Y = startPoint.Y
    },
    new Position(){
        X = startPoint.X,
        Y = startPoint.Y
    }
};
        var firstPathFound = false;
        if (startPoint.Y > 0 && map[startPoint.X, startPoint.Y - 1].south)
        {
            paths[0].Y--;
            firstPathFound = true;
        }
        if (startPoint.X < map.GetLength(0) - 1 && map[startPoint.X + 1, startPoint.Y].west)
        {
            var index = 0;
            if (firstPathFound)
                index++;
            else
                firstPathFound = true;
            paths[index].X++;
        }
        if (startPoint.Y < map.GetLength(1) - 1 && map[startPoint.X, startPoint.Y + 1].north)
        {
            var index = 0;
            if (firstPathFound)
                index++;
            paths[index].Y++;
        }
        if (startPoint.X > 0 && map[startPoint.X - 1, startPoint.Y].east)
        {
            paths[1].X--;
        }

        while (true)
        {
            for (var i = 0; i < paths.Length; i++)
            {
                if (map[paths[i].X, paths[i].Y].north && !map[paths[i].X, paths[i].Y - 1].Symbol.Equals('S'))
                {
                    paths[i].Y--;
                    map[paths[i].X, paths[i].Y].south = false;
                }
                else if (map[paths[i].X, paths[i].Y].east && !map[paths[i].X + 1, paths[i].Y].Symbol.Equals('S'))
                {
                    paths[i].X++;
                    map[paths[i].X, paths[i].Y].west = false;
                }
                else if (map[paths[i].X, paths[i].Y].south && !map[paths[i].X, paths[i].Y + 1].Symbol.Equals('S'))
                {
                    paths[i].Y++;
                    map[paths[i].X, paths[i].Y].north = false;
                }
                else if (map[paths[i].X, paths[i].Y].west && !map[paths[i].X - 1, paths[i].Y].Symbol.Equals('S'))
                {
                    paths[i].X--;
                    map[paths[i].X, paths[i].Y].east = false;
                }
            }

            answer++;

            if (paths[0].X == paths[1].X && paths[0].Y == paths[1].Y)
                break;
        }
        Console.WriteLine($"The Result of Part 1 is: {answer}");
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
    public bool north;
    public bool east;
    public bool south;
    public bool west;
    public bool scheduleToRemove;

    public Point(char symbol, int x, int y)
    {
        this.Symbol = symbol;
        this.X = x;
        this.Y = y;
        SetConnections();
    }

    private void SetConnections()
    {
        switch (Symbol)
        {
            case 'S':
                north = true;
                east = true;
                south = true;
                west = true;
                break;
            case 'F':
                north = false;
                east = true;
                south = true;
                west = false;
                break;
            case '-':
                north = false;
                east = true;
                south = false;
                west = true;
                break;
            case '7':
                north = false;
                east = false;
                south = true;
                west = true;
                break;
            case '|':
                north = true;
                east = false;
                south = true;
                west = false;
                break;
            case 'J':
                north = true;
                east = false;
                south = false;
                west = true;
                break;
            case 'L':
                north = true;
                east = true;
                south = false;
                west = false;
                break;
        }
    }

    public void ScheduleToRemove()
    {
        scheduleToRemove = true;
    }
    public void CleanUp()
    {
        if (scheduleToRemove)
        {
            Symbol = '.';
            north = false;
            east = false;
            south = false;
            west = false;
        }
    }
}
class Position
{
    public int X { get; set; }
    public int Y { get; set; }
}