using AdventOfCode2024.Day1;
using AdventOfCode2024.Day2;
using AdventOfCode2024.Day3;
using AdventOfCode2024.Day4;
using AdventOfCode2024.Day5;
using System.Diagnostics;
class Program
{
    static async Task Main(string[] args)
    {
        string day = "Day5";
        StreamReader sr = new StreamReader($"../../../{day}/input.txt");
        Day5 day5 = new Day5();
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var res = await day5.SolutionPart1Async(sr);
        stopWatch.Stop();
        Console.WriteLine(res);
        Console.WriteLine($"Execution Time = {stopWatch.Elapsed}");
    }

}