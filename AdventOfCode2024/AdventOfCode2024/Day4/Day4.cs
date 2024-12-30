using AdventOfCode2024.Utils;

namespace AdventOfCode2024.Day4
{
    internal class Day4
    {
        private async Task<char[,]> ReadLinesAsync(StreamReader sr)
        {
            var line = await sr.ReadLineAsync();
            List<string> lines = new();
            int width = 0;
            while (line != null)
            {
                lines.Add(line);
                width = line.Length;
                line = await sr.ReadLineAsync();
            }
            int height = lines.Count;
            char[,] res = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    res[i, j] = lines[i][j];
                }
            }
            return res;
        }

        public async Task<int> SolutionPart1Async(StreamReader sr)
        {
            var input = await ReadLinesAsync(sr);
            int count = 0;
            string word = "XMAS";
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == word.First())
                    {
                        for (int direction = 0; direction < Direction.allDirectionsWithDiagonals.Length; direction++)
                        {
                            bool isDirectionCorrect = true;
                            for (int charIndex = 0; charIndex < word.Length; charIndex++)
                            {
                                var positionRow = i + Direction.allDirectionsWithDiagonals[direction].Item1 * charIndex;
                                var positionCol = j + Direction.allDirectionsWithDiagonals[direction].Item2 * charIndex;
                                if (positionRow < 0 ||
                                    positionRow >= input.GetLength(0) ||
                                    positionCol < 0 ||
                                    positionCol >= input.GetLength(1) ||
                                    input[positionRow, positionCol] != word[charIndex]
                                    )
                                {
                                    isDirectionCorrect = false;
                                    break;
                                }
                            }
                            if (isDirectionCorrect)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        public async Task<int> SolutionPart2Async(StreamReader sr)
        {
            var input = await ReadLinesAsync(sr);
            int count = 0;
            string word = "MAS";
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == word[1])
                    {
                        var intermediateCount = 0;
                        for (int direction = 0; direction < Direction.Diagonals.Length; direction++)
                        {
                            var invertedDiagonals = Tuple.Create(Direction.Diagonals[direction].Item1 * (-1), Direction.Diagonals[direction].Item2 * (-1));
                            bool isDirectionCorrect = true;
                            var row = i + invertedDiagonals.Item1;
                            var col = j + invertedDiagonals.Item2;
                            for (int charIndex = 0; charIndex < word.Length; charIndex++)
                            {
                                var positionRow = row + Direction.Diagonals[direction].Item1 * charIndex;
                                var positionCol = col + Direction.Diagonals[direction].Item2 * charIndex;
                                if (positionRow < 0 ||
                                    positionRow >= input.GetLength(0) ||
                                    positionCol < 0 ||
                                    positionCol >= input.GetLength(1) ||
                                    input[positionRow, positionCol] != word[charIndex]
                                    )
                                {
                                    isDirectionCorrect = false;
                                    break;
                                }
                            }
                            if (isDirectionCorrect)
                            {
                                intermediateCount++;
                            }
                        }
                        if(intermediateCount == 2)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
