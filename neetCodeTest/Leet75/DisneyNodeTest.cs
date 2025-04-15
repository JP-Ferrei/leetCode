using FluentAssertions;
using neetcode.Leet75;

namespace neetCodeTest.Leet75;

[TestFixture]
[TestOf(typeof(DisneyNode))]
public class DisneyNodeTest
{

    private Dictionary<string, DisneyNode> dict = [];

    [OneTimeSetUp]
    public void Initialize()
    {
        var n16 = new DisneyNode("N16", 8);
        var n15 = new DisneyNode("N15", 51);
        var n13 = new DisneyNode("N13", 26);
        var n12 = new DisneyNode("N12", 35);
        var n11 = new DisneyNode("N11", 6);
        
        var n10 = new DisneyNode("N10", 42, n15, n16);
        var n9 = new DisneyNode("N9", 3,null,n13);
        var n8 = new DisneyNode("N7", 23,null, n12);
        var n7 = new DisneyNode("N7", 12, n11);
        var n6 = new DisneyNode("N6", 3,null,n10);
        var n5 = new DisneyNode("N5", 2,n9);
        var n4 = new DisneyNode("N4", 6,n7,n8);
        var n3 = new DisneyNode("N3", 16,n5, n6);
        var n2 = new DisneyNode("N2", 8, n4);
        var root = new DisneyNode("N1", 15,n2,n3);

        dict.Add("N1", root);
        dict.Add("N2", n2);
        dict.Add("N3", n3);
        dict.Add("N4", n4);
        dict.Add("N5", n5);
        dict.Add("N6", n5);
        dict.Add("N7", n7);
        dict.Add("N8", n8);
        dict.Add("N9", n9);
        dict.Add("N10", n10);
        dict.Add("N11", n11);
        dict.Add("N12", n12);
        dict.Add("N13", n13);
        dict.Add("N15", n15);
        dict.Add("N16", n16);
    }
    
    public static object[] DivideCases =
    {
        new object[] {},
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 }
    };
    
    [TestCase( "N1", "N15" )]
    [TestCase("N4", "N12")]
    [TestCase("N5", "N13")]
    public void HighestDescendant(string root, string expected)
    {
        var expectedNode = dict[expected];
        var rootNode = dict[root];

        var returnedValue = DisneyNode.GetHighestDescendancy(rootNode);

        returnedValue.Should().BeSameAs(expectedNode);

    }
}