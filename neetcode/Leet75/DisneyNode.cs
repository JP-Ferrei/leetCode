using System.ComponentModel.Design;

namespace neetcode.Leet75;

public class DisneyNode
{
    public string Name { get; set; }
    public int  Value { get; set; }

    public DisneyNode? Left { get; set; }
    public DisneyNode? Right { get; set; }

    public DisneyNode(string name, int value, DisneyNode? left = null, DisneyNode? right = null)
    {
        Name = name;
        Value = value;
        Left = left;
        Right = right;
    }

    public static DisneyNode GetHighestDescendancy(DisneyNode root)
    {
        var returnValue = root;
        if (root.Left is not null)
        {
            var node = GetHighestDescendancy(root.Left);
            returnValue = returnValue.Value > node.Value ? returnValue : node;
        }
        
        if (root.Right is not null)
        {
            var node = GetHighestDescendancy(root.Right);
            returnValue = returnValue.Value > node.Value ? returnValue : node;
        }

        return returnValue;
    }
 
}
