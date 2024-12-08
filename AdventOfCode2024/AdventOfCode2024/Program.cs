using AdventOfCode2024.Day1;
using AdventOfCode2024.Day2;
class Program
{
    static void Main(string[] args)
    {
        string day = "Day2";
        StreamReader sr = new StreamReader($"../../../{day}/input.txt");
        Day2 day2 = new Day2();
        var res = day2.Solution(sr);
        Console.WriteLine(res);
    }
}