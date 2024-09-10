using static neetcode.Problems.LinkedListSolution;

namespace neetCodeTest.stru;

public class Tests
{

    [Test]
    public void Test1()
    {
        var list1 = new ListNode(1, new(2, new(4)));
        var list2 = new ListNode(1, new(3, new(5)));

        //List<int> output = [1, 1, 2, 3, 4, 5];

        var a = MergeTwoLists(list1, list2);
        while (a is not null)
        {
            Console.WriteLine(a.val);
            a = a.next;
        }
    }
}