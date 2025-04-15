using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Xsl;
using neetcode.DataStructures;

namespace neetcode.Leet75;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class TreeNode
{
    public int val {get; set; }
    public TreeNode? left {get; set; }
    public TreeNode? right {get; set; }
    
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public void Add(int value)
    {
        if (val <= value)
        {
            if (right is null)
            {
                right = new(value);
                return;
            }

            Add(right, value);
            return;
        }

        if (left is null)
        {
            left = new(value);
            return;
        }
        
        Add(left, value);
    }

    private void Add(TreeNode node, int value)
    {
         if (node.val <= value)
         {
             if (node.right is null)
             {
                 node.right = new(value);
                 return;
             }

             Add(node.right, value);
         }

         if (node.left is null)
         {
             node.left = new(value);
             return;
         }
         
         Add(node.left, value);           
    }

    public static TreeNode? Parse(IEnumerable<int?> list)
    {
        var queue = new Queue<TreeNode>();

        if (list.Any() is false)
        {
            return null;
        }
        
        var head =  new TreeNode(list.First().Value) ;
        
        queue.Enqueue(head);
        
        foreach (var chunk in list.Skip(1).Chunk(2))
        {
            var currNode = queue.Dequeue();

            switch (chunk)
            {
                case [var leftValue, var rightValue ] :
                    
                if (leftValue is not null)
                {
                    var leftNode = new TreeNode(leftValue.Value);
                    currNode.left = leftNode;
                    queue.Enqueue(leftNode);
                }

                if (rightValue is not null)
                {
                    var rightNode = new TreeNode(rightValue.Value);
                    currNode.right = rightNode;
                    queue.Enqueue(rightNode);
                }
                break;
                
                case [var leftValue] :
                    
                if (leftValue is not null)
                {
                    var leftNode = new TreeNode(leftValue.Value);
                    currNode.left = leftNode;
                    queue.Enqueue(leftNode);
                }
                    
                break;
            }
            
        }

        return head;
    }

    public static TreeNode? Find(TreeNode? node,int value)
    {
        if (node is null)
        {
            return null;
        }

        if (node.val == value)
        {
            return node;
        }

        return Find(node.left, value) ?? Find(node.right, value);
    }
}

public static class TreeSolutions
{
    public static int MaxDepth(TreeNode? root)
    {
        if(root is null)
            return 0;
        
        var depth = 1;
        var leftDepth = 0;
        var rightDepth = 0;

        if (root.left is not null)
        {
           leftDepth += MaxDepth(root.left);
        }
        
        if (root.right is not null)
        {
            rightDepth = MaxDepth(root.right);
        }

        depth += Math.Max(leftDepth, rightDepth);

        return depth;
    }
    
    public static bool LeafSimilar(TreeNode? root1, TreeNode? root2) 
    {
        if ((root1 is null && root2 is not null) || (root1 is not null && root2 is null))
        {
            return false;
        }

        void DFS(TreeNode? root, List<int> list)
        {
            if (root is null)
                return;
            
            if (root is { left: null, right: null })
            {
                list.Add(root.val);
            }
            
            DFS(root?.left, list);
            DFS(root?.right, list);
        }

        var leafs1 = new List<int>();
        var leafs2 = new List<int>();
        
        DFS(root1, leafs1);
        DFS(root2, leafs2);

        if (leafs1.Count != leafs2.Count)
        {
            return false;
        }

        return leafs1.Zip(leafs2).All(it => it.First == it.Second);
    }
    
    public static int GoodNodes(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        int DFS(TreeNode? root, List<int> parents)
        {
            if (root is null)
            {
                return 0;
            }

            var allLower = parents.All(it => it <= root.val) ? 1 : 0;
            
            List<int> newParents = [..parents, root.val];

            return DFS(root.left, newParents) + DFS(root.right, newParents) + allLower;
        }

        return DFS(root,[]);
    }

    public static int PathSum(TreeNode? root, int targetSum)
    {
        if (root is null)
        {
            return 0;
        }

        void Dfs(TreeNode? root, int targetSum, ref int answer)
        {
            if (root is null)
            {
                return;
            }

            if (root.val - targetSum == 0)
            {
                answer++;
                return;
            }

            
            Dfs(root.left, targetSum - root.val, ref answer);
            Dfs(root.left, targetSum, ref answer);
            
            Dfs(root.right, targetSum - root.val, ref answer);
            Dfs(root.right, targetSum, ref answer);
            
        }

        var answer = 0;
        Dfs(root, 8, ref answer);
        return answer;
    }

    public static int LongestZigZag(TreeNode? root)
    {
        var x = 0;
        int Dfs(TreeNode? root, bool isLeft, int zigZag)
        {
            if (root is null)
            {
                return 0;
            }

            x = Math.Max(x, zigZag);
            if (isLeft)
            {
                Dfs(root.right, true, zigZag + 1);
                Dfs(root.left, false, 1);
            }
            else
            {
                Dfs(root.right, false, zigZag + 1);
                Dfs(root.left, true, 1);
            }

            return zigZag;
        }
        Dfs(root.left, true, 1);
        Dfs(root.right, false, 1);
        return x;
    }
    
    public record Result(bool Left = false, bool Right = false)
    {
        public bool Done => Left && Right;
        
        public static Result operator |(Result left, Result right)
        {
            return new(
                left.Left | right.Left,
                left.Right | right.Right
            );
        }
    };
    
    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode? result = null;
        
        Result Dfs(TreeNode? root, TreeNode p, TreeNode q)
        {
            if (root is null)
            {
                return new Result();
            }
            
            var h = new Result(
                Left: root == p,
                Right: root == q
            );

            h |= Dfs(root.left, p, q) | Dfs(root.right, p, q);

            if (result is not null)
            {
                return h;
            }
            
            if (h.Done)
            {
                result = root;
                return h;
            }

            return h;
        }

        Dfs(root, p, q);
        return result;
    }
    
    
    public static IList<int> RightSideView(TreeNode? root)
    {
        var dict = new Dictionary<int, int>();

        void Dfs(TreeNode? root, int depth)
        {
            if (root is null)
            {
                return;
            }

            if (dict.TryAdd(depth, root.val));
            
            Dfs(root.right, depth+1);
            Dfs(root.left, depth+1);

        }
        
        Dfs(root, 1);
        
        return dict.Values.ToList();
    }
    
    public static int MaxLevelSum(TreeNode root)
    {
         var dict = new Dictionary<int, int>();
 
         void Dfs(TreeNode? root, int depth)
         {
             if (root is null)
             {
                 return;
             }

             if (dict.TryAdd(depth, root.val) is false)
             {
                 dict[depth] += root.val;
             }
             
             Dfs(root.right, depth+1);
             Dfs(root.left, depth+1);
 
         }
         
         Dfs(root, 1);

         return dict.MaxBy(it => it.Value).Key;
    }
    
    public static TreeNode? SearchBST(TreeNode? root, int val)
    {
        TreeNode? Dfs(TreeNode? innerRoot, int innerVal)
        {
            if (innerRoot is null)
            {
                return null;
            }

            return innerRoot.val == innerVal
                ? innerRoot
                : Dfs(innerRoot.left,innerVal) ?? Dfs(innerRoot.right,innerVal);
        }

        return Dfs(root, val);
    }
    
    public static TreeNode? DeleteNode(TreeNode? root, int key)
    {
        if (root is null)
        {
            return null;
        }

        if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (root.val < key)
        {
            root.right = DeleteNode(root.right, key);
        }
        else
        {
            if (root is { left: null })
                return root.right;
            if (root is { right: null }) return root.left;

            var curr = root.right;

            while (curr is { left: not null })
            {
                curr = curr.left;
            }

            root.val = curr.val;

            root.right = DeleteNode(root.right, root.val);

        }
        return root;

    }
}