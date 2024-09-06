namespace neetcode.Problems;

public static class SlidingWindow
{
    public static int MaxProfit(int[] prices)
    {
        var buyDay = -1;
        var sellDay = -1;

        var finalDiff = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            var buyValue = prices[i];
            for (int j = 0 + i; j < prices.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var sellValue = prices[j];
                var diff = sellValue - buyValue;
                System.Console.WriteLine($"i:[{i}:{buyValue}] j: [{j}: {sellValue}] diff: {diff}");
                if (diff > finalDiff)
                {
                    finalDiff = diff;
                    buyDay = i;
                    sellDay = j;
                }
            }
        }

        return finalDiff;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        return s.Aggregate(
            (longest: "", current: ""),
            (acc, c) =>
            {
                System.Console.WriteLine($"current {acc.current}");
                if (acc.current.Contains(c) is false)
                {
                    var str = acc.current + c;
                    if (acc.longest.Length <= str.Length)
                    {
                        return (str, str);
                    }

                    return (acc.longest, str);
                }

                if (acc.current[0] == c)
                {
                    System.Console.WriteLine($"first character equal current character");
                    return (acc.longest, acc.current[1..] + c);
                }

                return (acc.longest, c.ToString());
            },
            it => it.longest.Length
        );
    }

    public static int CharacterReplacement(string s, int k)
    {
        var result = s[1..]
            .Aggregate(
                (longest: 0, current: s[0].ToString()),
                (acc, c) =>
                {
                    var str = acc.current + c;
                    var leastCharacterSum = SumLeastRecurringCharacters(str);
                    System.Console.WriteLine(
                        $"[leastCharacterSum {leastCharacterSum}] <= [K {k}] {leastCharacterSum <= k} [str.Length{str.Length}] >= [acc.longest{acc.longest}]: {str.Length >= acc.longest}"
                    );

                    if (leastCharacterSum <= k && str.Length >= acc.longest)
                    {
                        return (str.Length, str);
                    }

                    return (acc.longest, acc.current[1..] + c);
                }
            );

        System.Console.WriteLine(result);
        return result.longest;
    }

    public static int SumLeastRecurringCharacters(string str)
    {
        var keys = str.GroupBy(it => it);
        var mostRecurringChar = keys.MaxBy(it => it.Count());
        if (mostRecurringChar is not null)
        {
            return keys.Where(it => it.Key != mostRecurringChar.Key).Sum(it => it.Count());
        }

        return 0;
    }

    public static bool CheckInclusion(string s1, string s2)
    {
        var sr = string.Join("", s1.Order());

        return s2.Aggregate(
                (list: new List<string>(), word: ""),
                (acc, next) =>
                {
                    var str = acc.word + next;

                    if (str.Length == s1.Length)
                    {
                        acc.list.Add(str);
                        return (acc.list, str[1..]);
                    }

                    return (acc.list, str);
                },
                it => it.list
            )
            .Any(it =>
            {
                var aa = string.Join("", it.Order());
                return sr == aa;
            });
    }

    public static string MinWindow(string s, string t)
    {
        var a = t.Length - 1;

        var ass = s.Aggregate(
            "",
            (acc, curr) =>
            {
                if (HasAllCharacters(acc, t))
                {
                    System.Console.WriteLine(acc);
                    return acc;
                }

                var word = acc + curr;
                return word;
            }
        );

        var ff = ass;
        while (true)
        {
            if (HasAllCharacters(ff, t) is false) { }
            ff = ff[1..];
        }
        return ff;
    }

    public static bool HasAllCharacters(string s1, string s2)
    {
        var main = s1;
        var comparer = s2;

        if (s1.Length < s2.Length)
        {
            return false;
        }

        while (main.Length <= 0)
        {
            if (comparer.Length == 0)
            {
                return true;
            }

            System.Console.WriteLine($"{main}, {comparer}");
            var index = main.IndexOf(comparer[0]);
            if (index == -1)
            {
                return false;
            }
            comparer = comparer[1..];
            main = main.Remove(index, 1);
        }

        return false;
    }
}
