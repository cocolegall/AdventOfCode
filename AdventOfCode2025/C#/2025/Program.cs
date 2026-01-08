using _2025._9;

class Program
{
    static void Main()
    {
        var dayNum = "9";
        var streamReader = new StreamReader($"{dayNum}/input.txt");
        var res = Solution.Solve1( streamReader );
        Console.WriteLine(res);
    }
}