using System.Text;
using neetcode;

namespace neetcode.Problems;

public static class Solution
{
    #region hasDuplicate
    public static bool hasDuplicate(int[] nums)
    {
        var itens = new List<int>();

        foreach (var num in nums)
        {
            if (itens.Contains(num))
            {
                return true;
            }

            itens.Add(num);
        }
        return false;
    }

    #endregion
    #region IsAnagram
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var word1 = strToDict(s);
        var word2 = strToDict(t);

        if (word1.Count != word2.Count)
        {
            return false;
        }

        foreach (var pair in word1)
        {
            if (word1.TryGetValue(pair.Key, out var c1) && word2.TryGetValue(pair.Key, out var c2))
            {
                if (c1 == c2)
                {
                    continue;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    private static Dictionary<char, int> strToDict(string str)
    {
        var dict = new Dictionary<char, int>();
        foreach (var character in str)
        {
            if (dict.TryGetValue(character, out var _))
            {
                dict[character]++;
            }
            else
            {
                dict.Add(character, 1);
            }
        }

        return dict.OrderBy(it => it.Key).ToDictionary(it => it.Key, it => it.Value);
    }

    #endregion
    #region TwoSum
    public static int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [nums[i], nums[j]];
            }
        }

        return [];
    }

    #endregion
    #region GroupAnagrams
    public static List<List<string>> GroupAnagrams(string[] strs)
    {
        if (strs.Length == 1)
        {
            return new() { strs.ToList() };
        }

        var strsDicts = strs.Select(it => (DictValueToString(strToDict(it)), it));

        var dict = new Dictionary<string, List<string>>();

        foreach (var (keydString, str) in strsDicts)
        {
            if (dict.TryGetValue(keydString, out var keysList))
            {
                keysList.Add(str);
            }
            else
            {
                dict.Add(keydString, new() { str });
            }
        }

        return dict.Select(it => it.Value).ToList();
    }

    private static string DictValueToString(Dictionary<char, int> dict)
    {
        var sb = new StringBuilder();

        foreach (var pair in dict)
        {
            sb.Append($"{pair.Key},{pair.Value}");
        }
        return sb.ToString();
    }
    #endregion

    #region TopKFrequent

    public static int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (dict.TryGetValue(num, out var _))
            {
                dict[num]++;
            }
            else
            {
                dict.Add(num, 1);
            }
        }

        return dict.OrderByDescending(it => it.Value).Take(k).Select(it => it.Key).ToArray();
    }
    #endregion

    #region x
    #endregion

    #region String Encode and Decode

    public static string Encode(IList<string> strs)
    {
        var bytesArray = strs.Select(it => Convert.ToBase64String(Encoding.UTF8.GetBytes(it)));

        return string.Join("***", bytesArray);
    }

    public static List<string> Decode(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return new();
        }

        var bytesArray = s.Split("***").Select(it => Encoding.UTF8.GetBytes(it));

        return bytesArray
            .Select(it =>
                Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(it)))
            )
            .ToList();
    }
    #endregion

    #region ProductExceptSelf
    public static int[] ProductExceptSelf(int[] nums)
    {
        var result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var sum = 1;

            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    sum *= nums[j];
                }
            }

            result.Add(sum);
        }

        return result.ToArray();
    }
    #endregion

    #region IsValidSudoku
    public static bool IsValidSudoku(char[][] board)
    {
        var middles = new (int x, int y)[]
        {
            (1, 1),
            (1, 4),
            (1, 7),
            (4, 1),
            (4, 4),
            (4, 7),
            (7, 1),
            (7, 4),
            (7, 7)
        };

        if (middles.Select(it => IsValidQuadrant(board, it.x, it.y)).Any(it => it is false))
        {
            return false;
        }

        for (var i = 0; i < board.Length; i++)
        {
            var row = board[i];
            if (HasDuplicatedValue(row))
            {
                return false;
            }

            var colum = new List<char>();
            for (int j = 0; j < board.Length; j++)
            {
                var collumnSet = new HashSet<int>();

                var cellCollumn = board[j][i];
                colum.Add(cellCollumn);
            }

            if (HasDuplicatedValue(colum))
            {
                return false;
            }
        }

        return true;
    }

    private static bool HasDuplicatedValue(IEnumerable<char> cellRows)
    {
        return cellRows
            .Where(it => it != '.')
            .ToList()
            .Aggregate(
                new Dictionary<char, int>(),
                (acc, it) =>
                {
                    if (acc.TryGetValue(it, out var _))
                    {
                        acc[it]++;
                    }
                    else
                    {
                        acc.Add(it, 1);
                    }
                    return acc;
                },
                it => it.Any(it => it.Value > 1)
            );
    }

    private static bool IsValidQuadrant(char[][] board, int x, int y)
    {
        var adjacents = new (int x, int y)[]
        {
            (-1, -1),
            (0, -1),
            (1, -1),
            (-1, 0),
            (0, 0),
            (1, 0),
            (-1, 1),
            (0, 1),
            (1, 1)
        };

        var cells = adjacents.Select(it => board[x + it.x][y + it.y]);

        return HasDuplicatedValue(cells) is false;
    }
    #endregion

    public static int LongestConsecutive(int[] nums)
    {
        if (nums.Count() == 0)
        {
            return 0;
        }
        var a = nums.Order().ToList();
        a.print();
        int? prev = null;
        int sum = 0;
        int sequence = 0;

        return a.Aggregate(
            (prev, sum, sequence),
            (acc, next) =>
            {
                System.Console.WriteLine(
                    $"prev: {acc.prev} next:{next} sum: {acc.sum} sequence: {acc.sequence}"
                );
                if (acc.prev is not null && acc.prev + 1 == next)
                {
                    System.Console.WriteLine("xxxx");
                    return (next, acc.sum + 1, acc.sequence + 1);
                }

                System.Console.WriteLine("yyy");
                return (next, 0, acc.sequence);
            },
            it => (it.sum == 0 ? it.sequence : it.sum) + 1
        );
    }
}
