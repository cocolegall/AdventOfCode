using System.Runtime.ExceptionServices;

namespace AdventOfCode2024.Day4
{
    internal class Day4
    {
        private async Task<char[,]> ReadLinesAsync(StreamReader sr)
        {
            var line = await sr.ReadLineAsync();
            List<string> lines = new();
            int width = 0;
            while(line != null)
            {
                lines.Add(line);
                width = line.Length;
                line = await sr.ReadLineAsync();
            }
            int height = lines.Count;
            char[,] res = new char[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    res[i,j] = lines[i][j];
                }
            }
            return res;
        }
        
        public async Task<int> SolutionPart1Async(StreamReader sr)
        {
            var input = await ReadLinesAsync(sr);
            int count = 0;
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i,j] == 'X')
                    {
                        count += CheckHorizontal(i, j, input);
                        count += CheckVert(i, j, input);
                        count += CheckDiag(i, j, input);
                    }
                }
            }
            return count;
        }

        private int CheckHorizontal(int row, int col, char[,] array)
        {
            int res = 0;
            if (col <= array.GetLength(1) - 4)
            {
                char[] firstArrayToCheck = new char[3]
                {
                    array[row, col + 1],
                    array[row, col + 2],
                    array[row, col + 3],
                };

                if (IsXmas(firstArrayToCheck))
                {
                    res++;
                }
            }
            if(col >= 4)
            {
                char[] secondArrayToCheck = new char[3]
                {
                    array[row, col - 1],
                    array[row, col - 2],
                    array[row, col - 3],
                };

                if (IsXmas(secondArrayToCheck))
                {
                    res++;
                }
            }
            return res;
        }

        private int CheckVert(int row, int col, char[,] array)
        {
            int res = 0;
            if (row <= array.GetLength(0) - 4)
            {
                char[] firstArrayToCheck = new char[3]
                {
                    array[row + 1, col],
                    array[row + 2, col],
                    array[row + 3, col],
                };

                if (IsXmas(firstArrayToCheck))
                {
                    res++;
                }
            }
            if(row >= 3) 
            { 
                char[] secondArrayToCheck = new char[3]
                {
                    array[row - 1, col],
                    array[row - 2, col],
                    array[row - 3, col],
                };

                if (IsXmas(secondArrayToCheck))
                {
                    res++;
                }
            }
            return res;
        }

        private int CheckDiag(int row, int col, char[,] array)
        {
            int res = 0;
            if(row >= 3 && col >= 3)
            {
                char[] arrayToCheck = new char[3]
                {
                    array[row - 1, col - 1],
                    array[row - 2, col - 2],
                    array[row - 3, col - 3],
                };
                if (IsXmas(arrayToCheck))
                {
                    res++;
                }
            }
            if(row >= 3 && col <= array.GetLength(1) - 4)
            {
                char[] arrayToCheck = new char[3]
                {
                    array[row - 1, col + 1],
                    array[row - 2, col + 2],
                    array[row - 3, col + 3],
                };
                if (IsXmas(arrayToCheck))
                {
                    res++;
                }
            }
            if(row <= array.GetLength(0) - 4 && col >= 3)
            {
                char[] arrayToCheck = new char[3]
                {
                    array[row + 1, col - 1],
                    array[row + 2, col - 2],
                    array[row + 3, col - 3],
                };
                if (IsXmas(arrayToCheck))
                {
                    res++;
                }
            }
            if(row <= array.GetLength(0) - 4 && col<= array.GetLength(1) - 4)
            {
                char[] arrayToCheck = new char[3]
                {
                    array[row + 1, col + 1],
                    array[row + 2, col + 2],
                    array[row + 3, col + 3],
                };
                if (IsXmas(arrayToCheck))
                {
                    res++;
                }
            }
            return res;
        }

        private bool IsXmas(char[] content)
        {
            if (content[0] == 'M' && content[1] == 'A' && content[2] == 'S')
            {
                return true;
            }
            return false;
        }
    }
}
