using FluentAssertions;
using neetcode;
using neetcode.Leet75;

namespace neetCodeTest;

[TestFixture]
[TestOf(typeof(LeetCode75))]
public class LeetCode75Test
{
    private LeetCode75 leetCode75 = new LeetCode75();
    
    
    [TestCase("abc", "bca", true)]
    [TestCase("a", "aa", false)]
    [TestCase("cabbba", "abbccc", true)]
    [TestCase("uau", "ssx", false)]
    public void CloseStrings(string word1, string word2, bool expected)
    {
        var result = leetCode75.CloseStrings(word1, word2);
        result.Should().Be(expected);
    }

    [TestCase("5,3,6,2,4,null,7", 3)]
    public void DeleteNodeTest(string nodesStr, int key)
    {
        var list = new List<int>();
        foreach (var c in nodesStr.Split(','))
        {
            if (int.TryParse(c, out var number))
            {
                list.Add(number);
            }
        }

        var root = new TreeNode(list.First());

        foreach (var item in list.Skip(1))
        {
            root.Add(item);
        }
        
        var leet = new LeetCode75(); 
        var result = leet.DeleteNode(root, key);
    }
}