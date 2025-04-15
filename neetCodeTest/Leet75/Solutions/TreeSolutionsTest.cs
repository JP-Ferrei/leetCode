using FluentAssertions;
using neetcode.Leet75;

namespace neetCodeTest.Leet75.Solutions;

[TestFixture]
[TestOf(typeof(TreeSolutions))]
public class TreeSolutionsTest
{

    private static readonly object[] MaxDepthSource =
    {
        (object[]) [new List<int?> {3,9,20,null,null,15,7}, 3],
        (object[]) [new List<int?> {1,null,2}, 2]
    };

    [TestCaseSource(nameof(MaxDepthSource))]
    public void MaxDepthTest(List<int?> nodes, int expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.MaxDepth(root);

        result.Should().Be(expected);
    }

    private static readonly object[] LeafSimilarTreeTestSource =
    {
        (object[]) [new List<int?> {3,5,1,6,2,9,8,null,null,7,4},new List<int?> {3,5,1,6,7,4,2,null,null,null,null,null,null,9,8}, true
        ],
        (object[]) [new List<int?> {1,2,3}, new List<int?> {1,3,2}, false]
    };

    [TestCaseSource(nameof(LeafSimilarTreeTestSource))]
    public void LeafSimilarTreeTest(List<int?> a, List<int?> b, bool expected)
    {
        var aNode = TreeNode.Parse(a);
        var bNode = TreeNode.Parse(b);

        var result = TreeSolutions.LeafSimilar(aNode, bNode);
        result.Should().Be(expected);
    }

    private static readonly object[] GoodNodesSource =
    {
        (object[]) [new List<int?> {3,1,4,3,null,1,5}, 4],
        (object[]) [new List<int?> {3,3,null,4,2}, 3],
        (object[]) [new List<int?> {1}, 1]
    };

    [TestCaseSource(nameof(GoodNodesSource))]
    public void GoodNodesTest(List<int?> nodes, int expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.GoodNodes(root);

        result.Should().Be(expected);
    }

    private static readonly object[] PathSumSource =
    {
        (object[]) [new List<int?> {10,5,-3,3,2,null,11,3,-2,null,1}, 8, 3],
        (object[]) [new List<int?> {5,4,8,11,null,13,4,7,2,null,null,5,1}, 22, 3],
        (object[]) [new List<int?> {5,3,2,3,-2,null,1}, 8, 2],
    };

    [TestCaseSource(nameof(PathSumSource))]
    public void PathSumTest(List<int?> nodes, int targetSum, int expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.PathSum(root, targetSum);

        result.Should().Be(expected);
    }


    private static readonly object[] LongestZigZagSource =
    {
        (object[]) [new List<int?> {1,null,1,1,1,null,null,1,1,null,1,null,null,null,1}, 3],
        (object[]) [new List<int?> {1,1,1,null,1,null,null,1,1,null,1}, 4],
        (object[]) [new List<int?> {1}, 0],
    };

    [TestCaseSource(nameof(LongestZigZagSource))]
    public void LongestZigZagTest(List<int?> nodes, int expected)
    {
        var root = TreeNode.Parse(nodes);

        int result = TreeSolutions.LongestZigZag(root);

        result.Should().Be(expected);
    }

    private static readonly object[] LowestCommonAncestorSource =
    {
        (object[]) [new List<int?> {3,5,1,6,2,0,8,null,null,7,4}, 5,1,3],
        (object[]) [new List<int?> {3,5,1,6,2,0,8,null,null,7,4}, 5,4,5],
        (object[]) [new List<int?> {1,2}, 1,2,1],
    };

    [TestCaseSource(nameof(LowestCommonAncestorSource))]
    public void LowestCommonAncestorTest(List<int?> nodes, int a, int b, int expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.LowestCommonAncestor(root, TreeNode.Find(root, a), TreeNode.Find(root, b));

        result.Should().BeSameAs(TreeNode.Find(root, expected));
    }


    private static readonly object[] RightSideViewSource =
    {
        (object[]) [new List<int?> {1,2,3,null,5,null,4}, new List<int>{1,3,4}],
        (object[]) [new List<int?> {1,2,3,4,null,null,null,5}, new List<int>{1,3,4,5}],
        (object[]) [new List<int?> {1,null,3}, new List<int>{1,3}],
        (object[]) [new List<int?> {}, new List<int>{}],
    };

    [TestCaseSource(nameof(RightSideViewSource))]
    public void RightSideViewTest(List<int?> nodes, List<int> expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.RightSideView(root);

        result.Should().BeEquivalentTo(expected);
    }


    private static readonly object[] MaxLevelSumSource =
    {
        (object[]) [new List<int?> {1,7,0,7,-8,null,null}, 2],
    };

    [TestCaseSource(nameof(MaxLevelSumSource))]
    public void MaxLevelSumTest(List<int?> nodes, int expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.MaxLevelSum(root);

        result.Should().Be(expected);
    }

    private static readonly object[] SearchBSTSource =
    {
        (object[]) [new List<int?> {4,2,7,1,3}, 2, new List<int?>() {2,1,3}],
        (object[]) [new List<int?> {4,2,7,1,3}, 5, new List<int?>()],
    };

    [TestCaseSource(nameof(SearchBSTSource))]
    public void SearchBSTTest(List<int?> nodes, int val, List<int?> expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.SearchBST(root, val);

        result.Should().BeEquivalentTo(TreeNode.Parse(expected));
    }

    private static readonly object[] DeleteNodeSource =
    {
        (object[]) [new List<int?> {5,3,6,2,4,null,7}, 3, 5],
        (object[]) [new List<int?> {5,3,6,2,4,null,7}, 0, 5],
        (object[]) [new List<int?> {5,3,6,2,4,null,7}, 5, 6],
    };

    [TestCaseSource(nameof(DeleteNodeSource))]
    public void DeleteNodeTest(List<int?> nodes, int val, int expected)
    {
        var root = TreeNode.Parse(nodes);

        var result = TreeSolutions.DeleteNode(root, val);

        result.Should().Be(TreeNode.Find(root, expected));
    }

}
