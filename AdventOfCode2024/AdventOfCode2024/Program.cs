using AdventOfCode2024.Day1;
using AdventOfCode2024.Day2;
using AdventOfCode2024.Day3;
class Program
{
    static void Main(string[] args)
    {
        string day = "Day3";
        StreamReader sr = new StreamReader($"../../../{day}/input.txt");
        Day3 day3 = new Day3();
        var res = day3.SolutionPart2(sr);
        Console.WriteLine(res);
    }
}