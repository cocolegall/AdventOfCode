namespace AdventOfCode2024.Day5
{
    public class Day5
    {
        private async Task<string[]> ReadLinesAsync(StreamReader sr)
        {
            var line = await sr.ReadToEndAsync();
            var content = line.Replace("\r\n", "\n").Split("\n\n");
            return content;
            
        }

        public async Task<int> SolutionPart1Async(StreamReader sr)
        {
            var fileContent = await ReadLinesAsync(sr);
            var pageOrderingRules = fileContent[0].Split("\n");
            var PageUpdates = fileContent[1].Split("\n");
            Dictionary<int, HashSet<int>> orderingRulesDictBeforeKey = new Dictionary<int, HashSet<int>>();
            Dictionary<int, HashSet<int>> orderingRulesDictAfterKey = new Dictionary<int, HashSet<int>>();
            foreach(var rule in pageOrderingRules)
            {
                string[] ruleContent = rule.Split("|");
                var pagePrintedFirst = ruleContent[0];
                var pagePrintedLast = ruleContent[1];
                if(!int.TryParse(pagePrintedFirst,out int firstPage) || !int.TryParse(pagePrintedLast, out int lastPage))
                {
                    continue;
                }
                if (!orderingRulesDictBeforeKey.ContainsKey(firstPage))
                {
                    orderingRulesDictBeforeKey.Add(firstPage, new HashSet<int>() { lastPage});
                }
                if (!orderingRulesDictAfterKey.ContainsKey(lastPage))
                {
                    orderingRulesDictAfterKey.Add(lastPage, new HashSet<int>() { firstPage });
                }
                orderingRulesDictBeforeKey[firstPage].Add(lastPage);
                orderingRulesDictAfterKey[lastPage].Add(firstPage);
            }
            var updates = PageUpdates
                            .Select(s => s.Split(",").Select(v => int.Parse(v.ToString())).ToArray())
                            .ToArray();

            var wellOrderedUpdates = new List<int[]>();
            foreach(var update in updates)
            {
                bool isOrdered = true;
                for(int i = 0; i<update.Length; i++)
                {
                    if (!orderingRulesDictBeforeKey.ContainsKey(update[i]))
                    {
                        continue;
                    }
                    var nextPages = update
                        .Where((p, idx) => idx > i && !orderingRulesDictBeforeKey[update[i]].Contains(p))
                        .ToArray();
                    var beforePages = update
                        .Where((p, idx) => idx < i && !orderingRulesDictAfterKey[update[i]].Contains(p))
                        .ToArray();
                    if (nextPages.Any() || beforePages.Any())
                    {
                        isOrdered = false;
                        break;
                    }
                }
                if (isOrdered)
                {
                    wellOrderedUpdates.Add(update);
                }
            }
            int count = 0;
            foreach (var wellOrderedUpdate in wellOrderedUpdates)
            {
                var res = FindMiddleElement(wellOrderedUpdate);
                count += res;
            }
            return count;
        }

        private int FindMiddleElement(int[] array)
        {
            if(array.Length%2 == 0)
            {
                return array[array.Length/2];
            }
            return array[array.Length/2];
        }
    }
}
