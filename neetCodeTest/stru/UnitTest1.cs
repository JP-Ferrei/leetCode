using neetcode;
using neetcode.Leet75;
using static neetcode.LeetCode75;
using static neetcode.Problems.LinkedListSolution;
using ListNode = neetcode.Problems.LinkedListSolution.ListNode;

namespace neetCodeTest.stru;

public class Tests
{

    [Test]
    public void Test1()
    {
        var list1 = new ListNode(1, new(2, new(4)));
        var list2 = new neetcode.Problems.LinkedListSolution.ListNode(1, new(3, new(5)));

        //List<int> output = [1, 1, 2, 3, 4, 5];

        var a = MergeTwoLists(list1, list2);
        while (a is not null)
        {
            Console.WriteLine(a.val);
            a = a.next;
        }
    }

    [Test]
    public void teste()
    {
        var x = new LeetCode75();

        var result = x.DecodeString("100[leetcode]");

        var expected = "leetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcodeleetcode";
        Assert.That(result.Length, Is.EqualTo(expected.Length));
        Assert.That(result, Is.EqualTo(expected));

    }



    [Test]
    public void teste22()
    {
        var x = new LeetCode75();

        var result = x.PredictPartyVictory("DDRRR");
        Assert.That(result, Is.EqualTo("Dire"));
    }


    [Test]
    public void teste24()
    {
        var x = new LeetCode75();

        var result = x.OddEvenList(new LeetCode75.ListNode(1, new(2, new(3, new(4, new(5, new(6)))))));
    }


    [Test]
    public void teste25()
    {
        var x = new LeetCode75();

        TreeNode a = new(0, right: new(2, new(3), new(4, new(5, right: new(7, right: new(8))), new(6))));
        //new(1, new(1, new(1)),new(1,right:new(1)))
        var result = x.LongestZigZag(a);

    }

    [Test]
    public void teste27()
    {
        var x = new LeetCode75();

        TreeNode a = new(3, new(5, new(6), new(2, new(7), new(4))), new(1, new(), new(8)));
        var result = x.LowestCommonAncestor(a, new(5), new(4));

    }

    [Test]
    public void teste28()
    {
        var x = new LeetCode75();

        TreeNode a = new(5, new(3, new(2), new(4)), new(6, right: new(7)));
        var result = x.DeleteNode(a, 3);
    }

    [Test]
    public void teste29()
    {
        var x = new LeetCode75();
        var result = x.FindCircleNum([[1, 1, 0], [1, 1, 0], [0, 0, 1]]);
    }

    [Test]
    public void teste30()
    {
        var x = new LeetCode75();
        var result = x.MinReorder(6, [[0, 1], [1, 3], [2, 3], [4, 0], [4, 5]]);
    }


    [Test]
    public void teste31()
    {
        var x = new LeetCode75();
        //var result = x.NearestExit([['+','.','+','+','+','+','+'],
        //                            ['+','.','+','.','.','.','+'],
        //                            ['+','.','+','.','+','.','+'],
        //                            ['+','.','.','.','+','.','+'],
        //                            ['+','+','+','+','+','+','.']], [0,1]);
        //var result = x.NearestExit([['.', '.']], [0,1]);
        //var result = x.NearestExit([['+', '+', '+'], ['.', '.', '.'], ['+', '+', '+']], [1, 0]);
        //var result = x.NearestExit([['+','+','.','+'],['.','.','.','+'],['+','+','+','.']], [1,2]);
    }


    [Test]
    public void teste32()
    {
        var x = new LeetCode75();
        var result = x.OrangesRotting([[2, 1, 1], [1, 1, 0], [0, 1, 1]]);
        Assert.That(result, Is.EqualTo(4));

        result = x.OrangesRotting([[2, 1, 1], [0, 1, 1], [1, 0, 1]]);
        Assert.That(result, Is.EqualTo(-1));

        result = x.OrangesRotting([[0, 2]]);
        Assert.That(result, Is.EqualTo(0));

        result = x.OrangesRotting([[2, 1, 1], [1, 1, 1], [0, 1, 2]]);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void teste33()
    {

        var x = new LeetCode75();
        var result = x.FindKthLargest([3, 2, 1, 5, 6, 4], 2);
    }

    [Test]
    public void teste34()
    {

        var x = new SmallestInfiniteSet();
        x.AddBack(2);
        x.PopSmallest();
        x.PopSmallest();
        x.PopSmallest();
        x.AddBack(1);
        x.PopSmallest();
        x.PopSmallest();
        x.PopSmallest();
    }

    [Test]
    public void teste35()
    {

        var x = new LeetCode75();
        x.CombinationSum([2, 5, 6, 9], 9);
    }

    [Test]
    public void teste36()
    {

        var x = new LeetCode75();
        x.Permute([1, 2, 3]);
    }

    //[Test]
    //  public void teste37()
    //  {

    //      var root = new TreeNode(1, new(2, new(4),new(5, new(8),new(9))), new(3, new(6),new(7)));
    //      var x =new trees();
    //      var h = x.HoursToFlood(root, [5]);
    //      Assert.That(h, Is.EqualTo(4));
    //  }

}