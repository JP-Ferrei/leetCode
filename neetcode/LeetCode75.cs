using System.Text;

namespace neetcode;
internal class LeetCode75
{
    public string MergeAlternately(string word1, string word2)
    {
        var lenght = Math.Max(word1.Length, word2.Length);
        var sb = new StringBuilder();
        for (int i = 0; i < lenght - 1; i++)
        {
            if (i < word1.Length)
            {
                sb.Append(word1[i]);
            }
            if (i < word2.Length)
            {
                sb.Append(word1[2]);

            }
        }
        return sb.ToString();

    }

    public string GcdOfStrings(string str1, string str2)
    {
        return str2.Aggregate((sub: "", gdc: "", repetitions: 0), (acc, next) =>
        {
            var separator = acc.sub + next;

            var count = str1.Split(separator).Count(it => string.IsNullOrEmpty(it));
            if (count >= acc.repetitions)
            {
                return (separator, separator, count);
            }

            if (string.IsNullOrEmpty(acc.gdc) && count == 0)
            {
                return (separator, acc.gdc, acc.repetitions);
            }

            return (separator, acc.gdc, acc.repetitions);
        }, it => it.gdc);

    }
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
    }

    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (flowerbed.Length == 0) return false;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            var curr = flowerbed[i];
            int? prev = i > 0 ? flowerbed[i - 1] : null;
            int? next = i < flowerbed.Length - 1 ? flowerbed[i + 1] : null;

            if (curr == 1)
                continue;

            if (n == 0)
                break;

            if ((prev is null && next is null && curr == 0)
                || (prev is null && curr == 0 && next == 0)
                || (next is null && curr == 0 && prev == 0)
                || (curr == 0 && prev == 0 && next == 0)
            )
            {
                flowerbed[i] = 1;
                n--;
                continue;
            }
        }

        return n == 0;
    }

    public string ReverseVowels(string s)
    {
        var arr = s.ToCharArray();
        var i = 0;
        var j = s.Length - 1;

        var vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        while (i < j)
        {
            var first = s[i];
            var last = s[j];

            if (vowels.Contains(first) && vowels.Contains(last))
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                i++;
                j--;
            }

            if (vowels.Contains(last) is false)
            {
                j--;
            }


            if (vowels.Contains(first) is false)
            {
                i++;
            }
        }
        return new String(arr);
    }

    public string ReverseWords(string s)
    {
        var arr = s.Split(new char[] { ' ', '\t' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var i = 0;
        var j = arr.Length - 1;

        while (i < j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
            i++;
            j--;
        }
        return string.Join(" ", arr);

    }

    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        var prod = 1;
        foreach (var n in nums)
        {
            prod *= 1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] /= nums[i];

        }

        return result;

    }

    public bool IncreasingTriplet1(int[] nums)
    {
        if (nums.Length < 3)
            return false;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var first = nums[i];

            for (int j = 0 + i; j < nums.Length - 1; j++)
            {
                if (i == j)
                    continue;
                var middle = nums[j];

                for (int k = 0 + j; k < nums.Length; k++)
                {
                    if (k == j)
                        continue;
                    var last = nums[k];

                    if (first < middle && middle < last)
                        return true;
                }
            }
        }

        return false;

    }

    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
            return false;

        var a = int.MaxValue;
        var b = int.MaxValue;

        foreach (var item in nums)
        {
            if (item <= a)
            {
                a = item;
            }
            else if (item <= b)
            {
                b = item;
            }
            else
                return true;
        }
        return false;

    }

    public int Compress(char[] chars)
    {
        if (chars.Length < 1)
            return chars.Length;

        char? lastChar = null;
        var occurrances = 0;

        var index = 0;
        foreach (var c in chars)
        {
            if (lastChar is null)
            {
                lastChar = c;
                occurrances++;
                continue;
            }

            if (lastChar != c)
            {
                chars[index] = lastChar.Value;
                index++;
                if (occurrances == 1)
                {

                    lastChar = c;
                    occurrances = 1;
                    continue;
                }

                var x = occurrances.ToString().ToCharArray();
                foreach (var item in x)
                {
                    chars[index] = item;
                    index++;
                }
                lastChar = c;
                occurrances = 1;
            }
            else
            {
                occurrances++;
            }
        }

        chars[index] = lastChar.Value;
        index++;
        if (occurrances == 1)
            return index;
        var occurranceNChar = occurrances.ToString().ToCharArray();
        foreach (var item in occurranceNChar)
        {
            chars[index] = item;
            index++;
        }

        return index;
    }
}
