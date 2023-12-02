using System.Text;
using FluentAssertions;

namespace advent_of_code.tests._2023.day_02;

public class AoC202302
{
    private const string Red = "red";
    private const string Green = "green";
    private const string Blue = "blue";

    private readonly Game[] _games = File.ReadAllLines(@"2023\day-02\input.txt", Encoding.UTF8).Select(x =>
    {
        var parts = x.Split(":");
        var number = int.Parse(parts[0].Split(" ")[1]);
        var sets = parts[1].Split(";").Select(gs =>
        {
            var setParts = gs.Split(",").Select(gp =>
            {
                var cubeInfos = gp.Trim().Split(" ");
                var count = int.Parse(cubeInfos[0]);
                var color = cubeInfos[1].Trim();
                return new GameSetPart(color, count);
            }).ToArray();

            var gameSet = new Dictionary<string, int> { [Red] = 0, [Green] = 0, [Blue] = 0 };
            foreach (var gameSetPart in setParts)
            {
                gameSet[gameSetPart.Color] = gameSetPart.Count;
            }

            return gameSet;
        }).ToArray();

        return new Game(number, sets);
    }).ToArray();


    [Fact]
    public void PartOne()
    {
        var sum = _games.Sum(x => { return x.Sets.Any(w => w[Red] > 12 || w[Blue] > 14 || w[Green] > 13) ? 0 : x.Number; });

        sum.Should().Be(2149);
    }

    [Fact]
    public void PartTwo()
    {
        var sum = _games.Sum(x => Math.Max(x.Sets.Max(max => max[Red]), 1) * Math.Max(x.Sets.Max(max => max[Green]), 1) * Math.Max(x.Sets.Max(max => max[Blue]), 1));

        sum.Should().Be(71274);
    }
}