using System.Text.RegularExpressions;

namespace neetcode.Problems;

public static class TwoPointers
{
    public static bool IsPalindrome(string str)
    {
        var l = str.Where(ch => char.IsNumber(ch) || char.IsLetter(ch));
        str = string.Join("", l);

        System.Console.WriteLine(str);
        for (int i = 0; i < str.Length / 2; i++)
        {
            var first = str[i];
            var last = str[str.Length - i - 1];
            if (first.ToString().ToLower() != last.ToString().ToLower())
            {
                return false;
            }
        }

        return true;
    }

    public static int[] TwoSum(int[] numbers, int target)
    {
        var sum = 0;
        var i = 0;
        var j = numbers.Length - 1;
        while (i != j)
        {
            sum = numbers[i] + numbers[j];

            if (sum == target)
                return new int[] { i + 1, j + 1 };

            if (sum > target)
            {
                j--;
            }
            else
            {
                i++;
            }
        }
        return new int[] { };
    }

    public static List<List<int>> ThreeSum(int[] nums)
    {
        var result = new List<List<int>>();

        int i;
        int j = 1;
        int k = 2;
        for (i = 0; i < nums.Length - 2; i++)
        {
            if (i == j || i == k && i < nums.Length)
            {
                System.Console.WriteLine("i == j ou i == k");
                i++;
            }

            for (j = 1 + i; j < nums.Length - 1; j++)
            {
                if (j == k && j < nums.Length)
                {
                    System.Console.WriteLine("j == k");
                    j++;
                }

                for (k = 2 + i; k < nums.Length; k++)
                {
                    var sum = nums[i] + nums[j] + nums[k];

                    if (sum == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        result.Add(new() { nums[i], nums[j], nums[k] });
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    System.Console.WriteLine(
                        $" [ i:{i} v:{nums[i]} ] [ j:{j} v:{nums[j]} ] [ k:{k} v{nums[k]} ] sum {sum}"
                    );
                }
            }
        }
        return result;
    }

    public static int MaxArea(int[] heights)
    {
        var leftIndex = 0;
        var rightIndex = heights.Length - 1;
        var area = 0;

        while (leftIndex != rightIndex)
        {
            var left = heights[leftIndex];
            var right = heights[rightIndex];

            var height = Math.Min(left, right);
            var lenght = rightIndex - leftIndex;

            area = Math.Max(area, height * lenght);
            System.Console.WriteLine(area);

            if (left > right)
            {
                rightIndex--;
            }
            else
            {
                leftIndex++;
            }
        }

        return area;
    }

    public static int Trap(int[] heights)
    {
        if (heights.Count() < 2)
            return 0;

        heights = Trim(heights);
        return Trap2(heights);
    }

    public static int Trap2(IEnumerable<int> heights)
    {
        if (heights.Count() < 2)
            return 0;

        heights.print();
        var a = heights.Aggregate(
            (pilar1: 0, middles: new List<int>(), area: 0),
            (acc, next) =>
            {
                if (acc.pilar1 <= next)
                {
                    var sum = acc.middles.Sum();
                    acc.area += (acc.pilar1 * acc.middles.Count()) - sum;

                    return (next, new(), acc.area);
                }
                else
                {
                    System.Console.WriteLine($"add pit {next}");
                    acc.middles.Add(next);
                    return (acc.pilar1, acc.middles, acc.area);
                }
            }
        );

        return a.area + Trap2(a.middles);
    }

    //
    // public static int Trapx(IEnumerable<int> heights)
    // {
    //     if (heights.Count() < 2)
    //         return 0;
    //
    //     heights.print();
    //     TrapMiddle(heights.ToList(), heights.Count() / 2);
    // }
    //
    // public static int TrapMiddle(List<int> heights, int position)
    // {
    //     if (position - 1 >= 0)
    //     {
    //         var a = heights[position - 1];
    //     }
    //     if (position + 1 > heights.Count() - 1)
    //     {
    //         var b = heights[position + 1];
    //     }
    // }

    // public static (int, int) WalkLeft(List<int> heights, int position) { }
    //
    // public static (int, int) WalkRight(List<int> heights, int position) { }

    public static (int, List<int>, int) trapx(int pilar1, List<int> middles, int area, int next)
    {
        if (pilar1 <= next)
        {
            var sum = middles.Sum();
            area += (pilar1 * middles.Count()) - sum;

            return (next, new(), area);
        }
        else
        {
            System.Console.WriteLine($"add pit {next}");
            middles.Add(next);
            return (pilar1, middles, area);
        }
    }

    public static int Trap3(IEnumerable<int> heights)
    {
        if (heights.Count() < 2)
            return 0;

        heights.print();
        var a = heights.Aggregate(
            (pilar1: 0, curr: 0, middles: new List<int>(), area: 0),
            (acc, next) =>
            {
                System.Console.WriteLine("---------------------------------");
                System.Console.WriteLine($"next {next}");
                System.Console.WriteLine($"pilar {acc.pilar1}");
                System.Console.WriteLine($"curr {acc.curr}");
                System.Console.WriteLine($"area {acc.area}");
                acc.middles.print();
                System.Console.WriteLine("---------------------------------");

                if (acc.pilar1 <= next)
                {
                    var sum = acc.middles.Sum();
                    acc.area += (acc.pilar1 * acc.middles.Count()) - sum;

                    acc.middles.print();
                    return (next, next, new(), acc.area);
                }
                else if (acc.pilar1 > acc.curr && acc.curr < next)
                {
                    acc.area += next - acc.curr;

                    return (acc.pilar1, next, acc.middles.SkipLast(1).ToList(), acc.area);
                }
                else
                {
                    acc.middles.Add(next);
                    return (acc.pilar1, next, acc.middles, acc.area);
                }
            }
        );

        return a.area + Trap2(a.middles);
    }

    public static int[] Trim(int[] array)
    {
        var firstIndex = 0;

        while (array[firstIndex] == 0)
        {
            firstIndex++;
        }

        var lastIndex = array.Length - 1;
        while (array[lastIndex] < array[lastIndex - 1])
        {
            lastIndex--;
        }

        lastIndex++;
        return array[firstIndex..lastIndex];
    }
}
