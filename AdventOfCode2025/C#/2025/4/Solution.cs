namespace _2025._4
{
    internal class Solution
    {
        public static int Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            var rollOfPaper = new List<char[]>();
            while (line != null) 
            {
                var rollOfPaperLine = line;
                rollOfPaper.Add(rollOfPaperLine.ToArray());
                line = reader.ReadLine();
            }
            
            int count = 0;
            for(int i = 0;  i < rollOfPaper.Count; i++)
            {
                for (int j = 0; j < rollOfPaper[i].Length; j++)
                {
                    if(rollOfPaper[i][j] != '@')
                    {
                        continue;
                    }
                    int rollOfPaperSafeCounter = 0;
                    var dir = new List<(int, int)>()
                    {
                        (i - 1, j - 1),
                        (i - 1, j),
                        (i - 1, j + 1),
                        (i, j - 1),
                        (i, j + 1),
                        (i + 1, j - 1),
                        (i + 1, j),
                        (i + 1, j + 1)
                    };

                    foreach(var d in dir)
                    {
                        if(d.Item1 < 0 || d.Item2 < 0 || d.Item1 >= rollOfPaper.Count || d.Item2 >= rollOfPaper[i].Length)
                        {
                            continue;
                        }
                        if (rollOfPaper[d.Item1][d.Item2] == '@')
                        {
                            rollOfPaperSafeCounter += 1;
                        }
                    }

                    if (rollOfPaperSafeCounter < 4)
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

        public static int Solve2(StreamReader reader)
        {
            var line = reader.ReadLine();
            var rollOfPaper = new List<char[]>();
            while (line != null)
            {
                var rollOfPaperLine = line;
                rollOfPaper.Add(rollOfPaperLine.ToArray());
                line = reader.ReadLine();
            }
            
            var count = 0;
            SolveRollOfPaperState(rollOfPaper, ref count);
            return count;
        }

        public static void SolveRollOfPaperState(List<char[]> rollOfPaperState, ref int count)
        {
            var localCount = 0;
            var nextRollOfPaperState = new List<char[]>(rollOfPaperState.Count);
            foreach (char[] rollOfPaperLine in rollOfPaperState)
            {
                var newArr = new char[rollOfPaperLine.Length];
                Array.Copy(rollOfPaperLine, newArr, rollOfPaperLine.Length);
                nextRollOfPaperState.Add(newArr);
            }

            for (int i = 0; i < rollOfPaperState.Count; i++)
            {
                for (int j = 0; j < rollOfPaperState[i].Length; j++)
                {
                    if (rollOfPaperState[i][j] != '@')
                    {
                        continue;
                    }
                    int rollOfPaperSafeCounter = 0;
                    var dir = new List<(int, int)>()
                    {
                        (i - 1, j - 1),
                        (i - 1, j),
                        (i - 1, j + 1),
                        (i, j - 1),
                        (i, j + 1),
                        (i + 1, j - 1),
                        (i + 1, j),
                        (i + 1, j + 1)
                    };

                    foreach (var d in dir)
                    {
                        if (d.Item1 < 0 || d.Item2 < 0 || d.Item1 >= rollOfPaperState.Count || d.Item2 >= rollOfPaperState[i].Length)
                        {
                            continue;
                        }
                        if (rollOfPaperState[d.Item1][d.Item2] == '@')
                        {
                            rollOfPaperSafeCounter += 1;
                        }
                    }

                    if (rollOfPaperSafeCounter < 4)
                    {
                        localCount += 1;
                        nextRollOfPaperState[i][j] = 'x';
                    }
                }
            }
            if(localCount > 0)
            {
                count += localCount;
                SolveRollOfPaperState(nextRollOfPaperState, ref count);
            }
        }
    }
}
