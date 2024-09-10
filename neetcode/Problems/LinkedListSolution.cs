namespace neetcode.Problems;

public static class LinkedListSolution
{
    /** Definition for singly-linked list.  */
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static ListNode? ReverseList(ListNode head)
    {
        if (head is null)
            return null;

        return ReverseList(head, null);
    }

    private static ListNode? ReverseList(ListNode? source, ListNode? target)
    {
        if (source is null)
        {
            return target;
        }

        var aux = source.next;
        source.next = target;

        return ReverseList(aux, source);
    }

    public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        var dummy = new ListNode();
        Recurse(list1, list2, dummy);
        return dummy.next;
    }

    static void Recurse(ListNode? list1, ListNode? list2, ListNode target)
    {
        switch (list1, list2)
        {
            case (null, null):
                break;

            case (not null, null):
                Console.WriteLine(list1.val);
                target.next = list1;
                break;

            case (null, not null):
                Console.WriteLine(list2.val);
                target.next = list2;
                break;

            default:
                if (list1.val < list2.val)
                {
                    Console.WriteLine($"l1 {list2.val}");
                    target.next = list1;
                    Recurse(list1.next, list2, target.next);
                    break;
                }
                else
                {
                    target.next = list2;
                    Console.WriteLine($"l2 {list2.val}");
                    Recurse(list1, list2.next, target.next);
                    break;
                }
        }
    }
}
