namespace AdventOfCode2024.Utils
{
    public class Direction
    {
        public static Tuple<int, int>[] allDirectionsWithDiagonals { get; } =
        {
            Tuple.Create(0, 1),
            Tuple.Create(1, 0),
            Tuple.Create(0, -1),
            Tuple.Create(-1, 0),
            Tuple.Create(-1, 1),
            Tuple.Create(-1, -1),
            Tuple.Create(1, -1),
            Tuple.Create(1, 1),
        };
        public static Tuple<int, int>[] Diagonals { get; } =
        {
            Tuple.Create(-1, 1),
            Tuple.Create(-1, -1),
            Tuple.Create(1, -1),
            Tuple.Create(1, 1),
        };
    }
}
