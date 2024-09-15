
using neetcode.DataStructures;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;

namespace neetcode;
public class LeetCode75
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
    //public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    //{
    //}

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

    #region two Pointers

    public void MoveZeroes(int[] nums)
    {
        var i = 0;

        for (int j = 0; j < nums.Length; j++)
        {
            Console.WriteLine($"i {i} - {nums[i]} j: {j} - {nums[j]}");
            if (nums[j] == 0)
            {
                continue;
            }
            (nums[i], nums[j]) = (nums[j], nums[i]);
            i++;
        }
    }


    public bool IsSubsequence(string s, string t)
    {
        if (s == t)
            return true;

        if (s.Length == 0)
            return false;

        var j = 0;
        for (int i = 0; i < t.Length; i++)
        {
            if (s[j] == t[i])
            {
                j++;

                if (j >= s.Length)
                    return true;
            }
        }

        return false;
    }

    public int MaxArea(int[] height)
    {
        var i = 0;
        var j = height.Length - 1;

        var areaMax = 0;

        while (i < j)
        {
            var beg = height[i];
            var end = height[j];

            var distance = j - i;

            Console.WriteLine($"distance {distance}");
            var area = Math.Min(end, beg) * distance;
            Console.WriteLine($"area {area}");
            areaMax = Math.Max(area, areaMax);

            if (beg <= end)
            {
                i++;
            }
            else
            {
                j--;
            }
        }

        return areaMax;
    }

    public int MaxOperations(int[] nums, int k)
    {
        var order = nums.Order().ToArray();

        Console.WriteLine($"{string.Join(",", order)}");
        var i = 0;
        var j = order.Length - 1;
        var result = 0;
        while (i < j)
        {
            var first = order[i];
            var last = order[j];

            Console.WriteLine($"first {first} last {last}");
            var sum = first + last;
            if (sum < k)
            {
                i++;
            }
            else if (sum > k)
            {
                j--;
            }
            else if (sum == k)
            {
                result++;
                i++;
                j--;
            }
        }

        return result;
    }

    public double FindMaxAverage(int[] nums, int k)
    {

        if (k == nums.Length)
        {
            return (float)nums.Take(k).Sum() / k;
        }

        float maxAverage = 0;
        for (int i = 1; i < nums.Length - k; i++)
        {
            var sum = nums.Skip(i).Take(k).Sum();
            float average = (float)sum / k;
            Console.WriteLine(average);
            if (average > maxAverage)
                maxAverage = average;
        }

        return maxAverage;
    }

    #endregion


    public int LargestAltitude(int[] gain)
    {

        return gain.Aggregate((list: new List<int>() { 0 }, max: 0), (acc, curr) =>
        {
            acc.list.Add(curr);
            if (curr > acc.max)
            {
                return (acc.list, curr);
            }

            return (acc.list, acc.max);

        }, it => it.max);

    }

    public int PivotIndex(int[] nums)
    {
        var sumAll = nums.Sum();
        var sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0)
            {

                sum += nums[i - 1];
            }
            var rightSum = sumAll - (sum + nums[i]);

            Console.WriteLine($"index {i}  l: {sum} ///// r: {rightSum}");
            if (sum == rightSum) return i;
        }
        return -1;

    }

    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var n1 = nums1.ToHashSet();
        var n2 = nums2.ToHashSet();

        var list1 = new List<int>();
        var list2 = new List<int>();

        var max = Math.Max(n1.Count, n2.Count);

        foreach (var item in n1)
        {
            if (n2.Contains(item) is false)
            {
                list1.Add(item);
            }
        }

        foreach (var item in n2)
        {
            if (n1.Contains(item) is false)
            {
                list2.Add(item);
            }
        }

        return new List<IList<int>>() { list1, list2 };
    }

    public bool UniqueOccurrences(int[] arr)
    {

        var dict = new Dictionary<int, int>();
        foreach (var item in arr)
        {
            if (dict.ContainsKey(item) is false)
            {
                dict[item] = 1;
            }
            else
            {
                dict[item] = dict[item] + 1;
            }
        }

        return dict.Count == dict.Values.ToHashSet().Count;
    }

    //public bool CloseStrings(string word1, string word2)
    //{
    //    if (word1.Length != word2.Length)
    //        return false;



    //}

    public int EqualPairs(int[][] grid)
    {
        var rowsString = grid.Select(it => string.Join(",", it)).ToList();

        var collums = new List<string>();

        for (int i = 0; i < grid.Length; i++)
        {
            var collum = new int[grid.Length];
            for (var j = 0; j < grid.Length; j++)
            {
                collum[j] = grid[j][i];
            }

            collums.Add(string.Join(",", collum));
        }

        var equal = 0;
        foreach (var row in rowsString)
        {
            foreach (var collum in collums)
            {
                if (row == collum)
                {
                    equal++;
                }

            }
        }

        return equal;
    }

    public string RemoveStars(string s)
    {
        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (c == '*' && stack.TryPop(out _))
            {
            }
            else
            {
                stack.Push(c);
            }
        }

        var arr = new char[stack.Count];
        var i = 0;
        while (stack.TryPop(out var c))
        {
            arr[^i] = c;
            i++;
        }

        return new String(arr);

    }

    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();
        foreach (var asteroid in asteroids)
        {
            if (asteroid > 0)
            {
                stack.Push(asteroid);
                continue;
            }

            while (
                stack.Count > 0
                && stack.Peek() > 0
                && stack.Peek() < Math.Abs(asteroid)
            )
            {
                stack.Pop();
            }

            if (stack.Count == 0 || stack.Peek() < 0)
            {
                stack.Push(asteroid);
            }
            else if (stack.Peek() == Math.Abs(asteroid))
            {
                stack.Pop();
            }

        }

        return stack.Reverse().ToArray();
    }

    public string DecodeString(string s)
    {
        var stack = new Stack<char>(s);
        var sb = new StringBuilder();

        while (stack.TryPop(out var c))
        {
            if (char.IsLetter(c))
            {
                sb.Append(c);
            }
            else if (c == ']')
            {
                sb.Append(Recur(stack));
            }
        }

        return new String(sb.ToString().Reverse().ToArray());
    }

    private string Recur(Stack<char> stack)
    {
        var sb = new StringBuilder();
        while (stack.TryPop(out var pop))
        {
            switch (pop)
            {
                case ']':
                    sb.Append(Recur(stack));
                    break;
                case '[':
                    continue;
                case var x when char.IsLetter(x):
                    sb.Append(x);
                    break;

                default:
                    string number = pop.ToString();
                    while (stack.TryPeek(out var num) && char.IsNumber(num))
                    {
                        number = $"{num}{number}";
                        stack.Pop();
                    }

                    var str = sb.ToString();
                    sb.Clear();
                    for (global::System.Int32 i = 0; i < Convert.ToInt32(number); i++)
                    {
                        sb.Append(str);
                    }

                    return sb.ToString();
            }
        }

        return string.Empty;
    }

    public string PredictPartyVictory2(string senate)
    {
        var queue = new Queue<char>();
        var (rCount, dCount) = senate.Aggregate((R: 0, D: 0), (acc, curr) =>
        {
            queue.Enqueue(curr);
            return curr switch
            {
                'R' => (acc.R + 1, acc.D),
                _ => (acc.R, acc.D + 1)
            };
        });

        var scale = 0;

        while (rCount > 0 && dCount > 0)
        {
            var senator = queue.Dequeue();
            if (senator == 'R')
            {
                if (scale >= 0)
                {
                    dCount--;
                    queue.Enqueue(senator);
                }
                scale++;
            }
            else
            {

                if (scale <= 0)
                {
                    rCount--;
                    queue.Enqueue(senator);
                }
                scale--;
            }
        }

        return rCount > dCount ? "Radiant" : "Dire";
    }

    public string PredictPartyVictory(string senate)
    {
        var queue = new Queue<char>();
        var (rCount, dCount) = senate.Aggregate((R: 0, D: 0), (acc, curr) =>
        {
            queue.Enqueue(curr);
            return curr switch
            {
                'R' => (acc.R + 1, acc.D),
                _ => (acc.R, acc.D + 1)
            };
        });

        var rBanCount = 0;
        var dBanCount = 0;

        while (queue.TryDequeue(out var senator))
        {

            switch ((senator, rCount, dCount))
            {
                case (_, 0, _):
                    return "Dire";

                case (_, _, 0):
                    return "Radiant";
                case ('R', _, _):
                    BanOrIncreaseBanCount(queue, senator, ref rCount, ref rBanCount, ref dCount, ref dBanCount);
                    break;
                default:
                    BanOrIncreaseBanCount(queue, senator, ref dCount, ref dBanCount, ref rCount, ref rBanCount);
                    break;

            };
        }

        return string.Empty;
    }

    private static void BanOrIncreaseBanCount(
        Queue<char> queue, char senator,
        ref int sameSideCount, ref int sameBanCount,
        ref int opposingSideCount, ref int opossingBanCount
        )
    {

        //DDRRR

        if (opossingBanCount > 0)
        {
            opossingBanCount--;
            sameSideCount--;
            return;
        }
        queue.Enqueue(senator);
        sameBanCount++;

        while (queue.TryPeek(out var next) && next != senator && sameBanCount > 0)
        {
            queue.TryDequeue(out var _);
            opposingSideCount--;
            sameBanCount--;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode DeleteMiddle(ListNode head)
    {
        if (head is null or { next: null })
            return null;

        var count = 0;

        var node = head;
        while (node is not null)
        {
            count++;
            node = node.next;
        }
        var middle = count / 2;
        node = head;

        var curr = 0;
        while (node is not null)
        {

            if (curr + 1 == middle)
            {
                node.next = node.next.next;
            }

            curr++;
            node = node.next;
        }

        return head;
    }

    public ListNode DeleteMiddle2(ListNode head)
    {
        if (head is null or { next: null })
            return null;

        var prev = new ListNode(0, head);
        var slow = prev;
        var fast = head;

        while (fast is not null and { next: not null })
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        slow.next = slow.next.next;
        return prev.next;
    }
    public ListNode OddEvenList(ListNode head)
    {
        if (head is null or { next: null })
            return null;


        var prev = new ListNode(0, head);
        var firstEven = head.next;
        var node = head;
        var even = head.next;

        while (node.next is not null && even is not null)
        {
            node.next = node.next.next;
            if (node.next is not null)
            {
                node = node.next;
            }
            if (even.next is not null)
            {

                even.next = even.next.next;
                even = even.next;
            }

        }

        node.next = firstEven;
        return prev.next;
    }
    public ListNode ReverseList(ListNode head)
    {
        if (head is null)
            return head;

        ListNode aux = null;
        var node = head;
        while (node is not null)
        {
            var next = node.next;

            node.next = aux;
            aux = node;

            node = next;
        }

        return aux;
    }

    public int PairSum(ListNode head)
    {
        var node = head;
        var list = new List<int>();
        while (node is not null)
        {
            list.Add(node.val);
            node = node.next;
        }

        var max = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 == 0)
            {
                var j = list.Count - 1 - i;
                max = Math.Max(list[j] + list[i], max);

            }
        }

        return max;
    }

    public int PairSum2(ListNode head)
    {
        var slow = head;
        var fast = head.next;
        var list = new List<int>();

        while (fast.next is not null)
        {
            list.Add(slow.val);
            slow = slow.next;
            fast = fast.next.next;
        }
        var max = 0;

        for (int i = list.Count - 1; i >= 0; i--)
        {

            max = Math.Max(slow.val + list[i], max);
            slow = slow.next;

        }

        return max;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public int MaxDepth(TreeNode root)
    {
        int DFS(TreeNode root, int i)
        {
            if (root is null)
                return i;

            var a = DFS(root.left, i + 1);
            var b = DFS(root.right, i + 1);

            return Math.Max(a, b);
        }
        return DFS(root, 1);
    }

    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {

        void DFS(TreeNode root, StringBuilder sb)
        {
            if (root is null)
                return;

            if (root is { left: null, right: null })
            {
                sb.Append(root.val + ',');
            }

            DFS(root.left, sb);
            DFS(root.right, sb);
        }

        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        DFS(root1, sb1);
        DFS(root2, sb2);
        return sb1.ToString() == sb2.ToString();
    }

    public int GoodNodes(TreeNode root)
    {
        void DFS(TreeNode root, int max, ref int awnser)
        {
            if (root is null)
                return;

            if (root.val >= max)
                awnser++;
            DFS(root.left, Math.Max(root.val, max), ref awnser);
            DFS(root.right, Math.Max(root.val, max), ref awnser);

        }

        var awnser = 1;
        DFS(root, root.val, ref awnser);
        return awnser;
    }

    public int PathSum(TreeNode root, int targetSum)
    {
        if (root is null)
            return 0;

        return
            PathSum(root.left, targetSum)
            + PathSum(root.right, targetSum)
            + PathSumWithRoot(root, targetSum);
    }

    public int PathSumWithRoot(TreeNode root, int targetSum)
    {
        if (root is null)
            return 0;

        return (targetSum == root.val ? 1 : 0)
            + PathSumWithRoot(root.left, targetSum - root.val)
            + PathSumWithRoot(root.right, targetSum - root.val);
    }

    public int LongestZigZag(TreeNode root)
    {
        int DFS(TreeNode node, int direction, int chain)
        {
            if (node is null or { left: null, right: null })
                return chain;

            var a = chain;
            var b = chain;

            if (node.left is not null)
            {
                a = Math.Max(chain, DFS(node.left, -1, direction < 0 ? 1 : chain + 1));
            }

            if (node.right is not null)
            {
                b = Math.Max(chain, DFS(node.right, 1, direction > 0 ? 1 : chain + 1));
            }

            return Math.Max(a, b);
        }

        return DFS(root, 0, 0);
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        (bool hasP, bool hasQ) DFS(TreeNode root, TreeNode p, TreeNode q, ref TreeNode anwser)
        {
            var (hasP, hasQ) = (false, false);
            if (root is null)
                return (hasP, hasQ);

            var (leftP, leftQ) = DFS(root.left, p, q, ref anwser);
            var (rightP, rightQ) = DFS(root.right, p, q, ref anwser);

            if (root.val == p.val || leftP || rightP)
            {
                hasP = true;
            }

            if (root.val == q.val || leftQ || rightQ)
            {
                hasQ = true;
            }

            if (hasP && hasQ)
            {
                anwser = root;
                (hasP, hasQ) = (false, false);
            }

            return (hasP, hasQ);
        }

        TreeNode awnser = null;
        DFS(root, p, q, ref awnser);
        return awnser;
    }

    public IList<int> RightSideView(TreeNode root)
    {
        var dict = new Dictionary<int, int>();

        void DFS(TreeNode root, int depth, Dictionary<int, int> dict)
        {
            if (root == null)
                return;

            dict.TryAdd(depth, root.val);
            DFS(root.right, depth + 1, dict);
            DFS(root.left, depth + 1, dict);
        }

        DFS(root, 0, dict);
        return dict.Select(it => it.Value).ToList();
    }

    public int MaxLevelSum(TreeNode root)
    {
        void DFS(TreeNode root, int depth, Dictionary<int, int> dict)
        {
            if (root == null) return;


            if (dict.TryGetValue(depth, out var number))
            {
                dict[depth] = number + root.val;
            }
            else
            {
                dict[depth] = root.val;
            }

            DFS(root.left, depth + 1, dict);
            DFS(root.right, depth + 1, dict);
        }

        var dict = new Dictionary<int, int>();

        DFS(root, 1, dict);

        return dict.MaxBy(it => it.Value).Key;

    }

    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null)
            return root;

        if (root.val == val)
            return root;

        TreeNode? node = null;
        if (root.val > val)
        {
            node = SearchBST(root.left, val);
        }
        else
        {
            node = SearchBST(root.right, val);
        }

        return node;
    }

    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is null)
            return root;

        if (root.val == key)
        {
            var newNode = root switch
            {
                { left: null, right: null } => null,
                { left: null, right: not null } => root.right,
                { left: not null, right: null } => root.left,
                var x => highest(x.left),
            };
            newNode.right = root.right;
            newNode.left = root.left;
            root = newNode;

        }
        else if (root.val < key)
        {
            var node = DeleteNode(root.right, key);
            if (node is not null)
            {
                root.right = node;
            }
        }
        else
        {
            var node = DeleteNode(root.left, key);
            if (node is not null)
            {
                root.left = node;
            }
        }

        return root;
    }
    public TreeNode? highest(TreeNode? node)
    {
        if (node is null or { right: null, left: null })
        {
            return node;
        }

        TreeNode? newNOde = null;
        newNOde = highest(node.right);
        return newNOde is null ? highest(node.left) : newNOde;
    }

    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var queue = new Queue<IList<int>>();
        var keys = new HashSet<int>() { 0 };

        queue.Enqueue(rooms[0]);

        while (queue.TryDequeue(out var room))
        {
            foreach (var key in room)
            {
                if (keys.Contains(key) is false)
                {
                    queue.Enqueue(rooms[key]);
                    keys.Add(key);
                }
            }
        }

        return rooms.Count == keys.Count;
    }

    public int FindCircleNum(int[][] isConnected)
    {
        var queue = new Queue<int[]>();
        var visited = new HashSet<int>(isConnected.Length);
        var provinces = 0;

        for (int i = 0; i < isConnected.Length; i++)
        {
            if (visited.Contains(i))
            {
                continue;
            }
            queue.Enqueue(isConnected[i]);
            visited.Add(i);
            provinces++;

            while (queue.TryDequeue(out var city))
            {
                for (int j = 0; j < city.Length; j++)
                {
                    var connected = city[j];
                    if (connected == 1 && visited.Contains(j) is false)
                    {
                        queue.Enqueue(isConnected[j]);
                        visited.Add(j);
                    }
                }
            }
        }

        return provinces;
    }

    class MinNode
    {
        public int Val { get; set; }
        public HashSet<MinNode> Going { get; } = [];
        public HashSet<MinNode> Recieve { get; } = [];

        public MinNode(int val = 0)
        {
            Val = val;
        }
    }

    public int MinReorder(int n, int[][] connections)
    {
        var dict = new Dictionary<int, MinNode>(n);

        for (int i = 0; i < connections.Length; i++)
        {
            if (dict.TryGetValue(connections[i][0], out var node) is false)
            {
                node = new MinNode(connections[i][0]);
                dict[connections[i][0]] = node;
            }

            if (dict.TryGetValue(connections[i][1], out var going) is false)
            {
                going = new MinNode(connections[i][1]);
                dict[connections[i][1]] = going;
            }

            node.Going.Add(going);
            going.Recieve.Add(node);
        }

        var visited = new HashSet<int>();

        int DFS(MinNode node)
        {
            visited.Add(node.Val);
            var change = 0;
            foreach (var going in node.Going)
            {
                if (visited.Contains(going.Val) is false)
                {
                    change++;
                    change += DFS(going);
                }
            }

            foreach (var recieve in node.Recieve)
            {
                if (visited.Contains(recieve.Val) is false)
                {
                    change += DFS(recieve);
                }
            }

            return change;
        }

        var a = DFS(dict[0]);
        return a;
    }

    public int NearestExit(char[][] maze, int[] entrance)
    {
        var queue = new Queue<int[]>();
        var viseted = new HashSet<(int x, int y)>();
        var parent = new Dictionary<(int x, int y), (int x, int y)>();

        queue.Enqueue(entrance);

        var directions = new int[][]
        {
            [-1,0],
            [1,0],
            [0,-1],
            [0,1],
        };

        var lastPosition = (0, 0);
        while (queue.TryDequeue(out var position))
        {
            //Console.Clear();
            var (x, y) = (position[0], position[1]);

            if (IsInsideBoundaries(maze, x, y) is false)
            {
                lastPosition = (x, y);
                break;
            }

            viseted.Add((x, y));
            //PrintBoard(maze, viseted, entrance);

            var positions = directions
                .Select(it => (x + it[0], y + it[1]))
                .Where(it =>
                {
                    if (viseted.Contains((it.Item1, it.Item2)) is false)
                    {
                        var isInside = IsInsideBoundaries(maze, it.Item1, it.Item2);
                        if (isInside)
                        {
                            var value = maze[it.Item1][it.Item2];
                            if (value == '.')
                            {
                                return true;
                            }
                        }

                        var currIsntEntrance = (x == entrance[0] && y == entrance[1]) is false;

                        if (isInside is false && currIsntEntrance)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                );

            foreach (var (nextX, nextY) in positions)
            {
                parent.TryAdd((nextX, nextY), (x, y));
                queue.Enqueue([nextX, nextY]);
            }
        }


        return parent.Count == 0 || lastPosition ==(0,0) ? -1 : CountSteps(parent, (entrance[0], entrance[1]), lastPosition, 0);

    }

    public void PrintBoard(char[][] maze, HashSet<(int,int)> visiteds, int[] entrance)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < maze.Length; i++)
        {
            for (int j = 0; j < maze[i].Length; j++)
            {
                var cell = maze[i][j];
                var c = cell switch
                {
                    var x when entrance[0] == i && entrance[1] == j => 'O',
                    var x when visiteds.Contains((i, j)) => 'X',
                    '+' => 'W',
                    '.' => ' ',
                    _ => ' ',
                };
                sb.AppendFormat("{0}", c);
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
    }

    public bool IsInsideBoundaries(char[][] maze, int x, int y) => (x >= 0 && x < maze.Length) && (y >= 0 && y < maze[0].Length);
    public int CountSteps(Dictionary<(int x, int y), (int x, int y)> dict, (int x, int y) startPosition, (int x, int y) lastPosition, int step)
    {
        var nextPosition = dict[lastPosition];
        if (nextPosition == startPosition)
        {
            return step;
        }

        return CountSteps(dict, startPosition, nextPosition, step + 1);
    }

}
