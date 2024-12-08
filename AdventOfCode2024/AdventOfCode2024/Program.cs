using AdventOfCode2024.Day1;
using AdventOfCode2024.Day2;
class Program
{
    static void Main(string[] args)
    {
        string day = "Day1";
        StreamReader sr = new StreamReader($"../../../{day}/input.txt");
        Day1 day1 = new Day1();
        var res = day1.SolutionPart2(sr);
        Console.WriteLine(res);
    }
}