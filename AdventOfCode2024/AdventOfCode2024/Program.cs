using AdventOfCode2024.Day1;
using AdventOfCode2024.Day2;
using AdventOfCode2024.Day3;
using AdventOfCode2024.Day4;
class Program
{
    static async Task Main(string[] args)
    {
        string day = "Day4";
        StreamReader sr = new StreamReader($"../../../{day}/input.txt");
        Day4 day4 = new Day4();
        var res = await day4.SolutionPart1Async(sr);
        Console.WriteLine(res);
    }

}