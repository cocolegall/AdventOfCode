using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters;

namespace _2025._6
{
    internal class Solution
    {
        public static long Solve1(StreamReader reader)
        {
            var line = reader.ReadLine();
            var operators = new List<char>();
            var parameters = new List<long>();
            while (line != null)
            {
                if (line[0] != '*' && line[0] != '+')
                {
                    for(int i = 0; i < line.Length; i++)
                    {
                        string intToAdd = "";
                        while (i < line.Length && line[i] != ' ')
                        {
                            intToAdd += line[i];
                            i++;
                        }
                        if(intToAdd.Length == 0)
                        {
                            continue;
                        }
                        parameters.Add(Convert.ToInt32(intToAdd));
                    }
                    line = reader.ReadLine();
                    continue;
                }

                for(int i = 0; i < line.Length; i++)
                {
                    while(i < line.Length && line[i] != ' ')
                    {
                        operators.Add(line[i]);
                        i++;
                    }
                }
                line = reader.ReadLine();
            }
            var lineSize = operators.Count;
            var add = (long a, long b) => a + b;
            var multiply = (long a, long b) => (a * b);
            long count = 0;
            for(int i = 0; i < lineSize; i++)
            {
                Func<long, long, long> operation;
                if (operators[i] == '+')
                {
                    operation = add;
                }
                else if (operators[i] == '*')
                {
                    operation = multiply;
                }
                else
                {
                    throw new NotImplementedException();
                }
                var times = parameters.Count / lineSize;
                var res = parameters[i];
                for(int j = 1; j < times; j++)
                {
                    res = operation(res, parameters[i+lineSize*j]);
                }
                count += res;
            }

            return count;
        }

        public static long Solve2(StreamReader reader)
        {
            var line = reader.ReadLine();
            List<string> rawInput = new List<string>();
            while (line != null)
            {
                rawInput.Add(line);
                line = reader.ReadLine();
            }
            var rawOperators = rawInput[rawInput.Count - 1];
            rawInput.RemoveAt(rawInput.Count - 1);
            int numberOfParametersPerProblems = rawInput.Count;
            int inputLineSize = rawInput[0].Length;

            List<long[]> cephalopodsInputs = new List<long[]>();
            List<long> cephalopodsInput = new List<long>();
            for (int i = 0; i < inputLineSize; i++)
            {
                string inputColumns = "";
                for(int j = 0; j < numberOfParametersPerProblems; j++)
                {
                    inputColumns += rawInput[j][i];
                }

                var isSeparator = !inputColumns.Where(e => e != ' ').Any();
                if (isSeparator)
                {
                    cephalopodsInputs.Add(cephalopodsInput.ToArray());
                    cephalopodsInput.Clear();
                    continue;
                }
                cephalopodsInput.Add(Convert.ToInt32(inputColumns.ToString()));
                if (i == (inputLineSize - 1))
                {
                    cephalopodsInputs.Add(cephalopodsInput.ToArray());
                }
            }

            var operators = new List<string>();
            foreach(var op in rawOperators)
            {
                if(op != ' ')
                {
                    operators.Add(op.ToString());
                }
            }

            var add = (long a, long b) => a + b;
            var multiply = (long a, long b) => (a * b);
            long count = 0;
            for(int i = 0; i < operators.Count; i++)
            {
                Func<long, long, long> operation;
                if (operators[i] == "+")
                {
                    operation = add;
                }
                else if (operators[i] == "*")
                {
                    operation = multiply;
                }
                else
                {
                    throw new NotImplementedException();
                }
                var res = cephalopodsInputs[i][0];
                for(int j = 1; j < cephalopodsInputs[i].Length; j++)
                {
                    res = operation(res, cephalopodsInputs[i][j]);
                }
                count += res;
            }

            return count;
        }
    }
}
