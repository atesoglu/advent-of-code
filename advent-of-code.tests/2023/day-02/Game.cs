namespace advent_of_code.tests._2023.day_02;

public class Game(int number, IEnumerable<Dictionary<string, int>> sets)
{
    public int Number { get; } = number;
    public IEnumerable<Dictionary<string, int>> Sets { get; } = sets;
}

public class GameSetPart(string color, int count)
{
    public string Color { get; } = color;
    public int Count { get; } = count;
}