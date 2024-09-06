namespace neetcode.DataStructures;

public class LinkedList
{
    private Node? Head;
    private int _size = 0;

    public LinkedList() { }

    public int Get(int index)
    {
        var insideIndex = 0;

        if (Head is null)
        {
            return -1;
        }

        var node = Head;

        while (node is not null)
        {
            if (insideIndex == index)
            {
                return node.Data;
            }

            node = node.Next;
            insideIndex++;
        }

        return -1;
    }

    public void InsertHead(int val)
    {
        var newHead = new Node { Data = val };
        _size++;
        if (Head is null)
        {
            Head = newHead;
            return;
        }

        newHead.Next = Head;
        Head = newHead;
    }

    public void InsertTail(int val)
    {
        var newTail = new Node { Data = val };
        _size++;
        if (Head is null)
        {
            Head = newTail;
            return;
        }

        var node = Head;
        while (node is not null)
        {
            if (IsTail(node))
            {
                node.Next = newTail;
                return;
            }

            node = node.Next;
        }
    }

    private bool IsTail(Node node)
    {
        return node.Next is null;
    }

    public bool Remove(int index)
    {
        if (Head is null)
        {
            return false;
        }

        if (index > _size - 1)
        {
            return false;
        }

        var node = Head;

        if (index == 0)
        {
            Head = Head.Next;
            _size--;
            return true;
        }

        var insideIndex = 0;
        while (node is not null)
        {
            if (insideIndex + 1 == index)
            {
                var nodeToExclude = node.Next;
                node.Next = nodeToExclude?.Next;
                _size--;

                return true;
            }

            node = node.Next;
            insideIndex++;
        }

        return false;
    }

    public List<int> GetValues()
    {
        var values = new List<int>();

        if (Head is null)
        {
            return values;
        }

        var node = Head;
        while (node is not null)
        {
            values.Add(node.Data);

            node = node.Next;
        }

        return values;
    }
}

public class Node
{
    public Node? Next { get; set; }
    public int Data { get; set; }
}

/*
 * head 1 = [1]
 * head 2 = [2,1]
 * tail 3 =  [2,1,3]
 * tail 4 = [2,1,3,4]
 * head 5 = [5,2,1,3,4]
 * get 0 = 5
 * get 2 = 1
 * get 4 = 4
 * remove 2 = true = [5,2,3,4]
 * remove 0 = true = [2,3,4]
 * head 6 = [6,2,3,4]
 * tail 7 =[6,2,3,4,7]
 * get values = [6,2,3,4,7]
 * get 5 = -1
*/
