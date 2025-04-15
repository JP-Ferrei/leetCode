using FluentAssertions;
using neetcode.Leet75.Solutions;

namespace neetCodeTest.Leet75.Solutions;

[TestFixture]
public class GraphsSolutionsTest
{

    private static readonly object[] CanVisitAllRoomsSource =
    {
    //     new object[] { new List<List<int>>() { [1],[2],[3],[] }, true },

    //     new object[] { new List<List<int>>() { [1,3],[3,0,1],[2],[0]}, true },
     };

    //[TestCaseSource(nameof(CanVisitAllRoomsSource))]
    [TestCase("[[1],[2],[3],[]]", true)]
    [TestCase("[[1,3],[3,0,1],[2],[0]]", false)]
    [TestCase("[[1],[1]]", true)]
    [TestCase("[[2],[],[1]]", true)]
    public void CanVisitAllRoomsTest(string str, bool expected)
    {
        var graph = Graphs.Parse(str);
        var result = GraphsSolution.CanVisitAllRooms(graph);

        result.Should().Be(expected);
    }

    // private static readonly object[] yySource = 
    // {
    //     new object[] {new List<int?> {}, 3},
    //     new object[] {new List<int?> {}, 2},
    // };
    //
    // [TestCaseSource(nameof(yySource))]
    // public void yyTest(List<int?> nodes, int expected)
    // {
    //     var root = TreeNode.Parse(nodes);
    //
    //     var result = TreeSolutions.yy(root);
    //
    //     result.Should().Be(expected);
    // }
}