using System.Text;

namespace neetcode.Leet75.Solutions;
public class Graphs
{

    public static List<List<int>> Parse(string str)
    {
        var queue = new Queue<char>(str[1..^1]);

        var graph = new List<List<int>>();
        var sb = new StringBuilder();

        var currentList = new List<int>();
        while (queue.TryDequeue(out var item))
        {
            if (item is '[')
            {
                currentList = [];
                continue;
            }

            if (char.IsDigit(item))
            {
                sb.Append(item);

                if (queue.TryPeek(out var peek))
                {
                    while (char.IsDigit(peek))
                    {
                        queue.Dequeue();
                        sb.Append(peek);
                        peek = queue.Peek();
                    }
                }

                var itemString = sb.ToString();
                sb.Clear();
                currentList.Add(int.Parse(itemString));
                continue;
            }

            if (item is ',')
            {
                continue;
            }

            if (item is ']')
            {
                graph.Add(currentList);
                continue;
            }
        }

        return graph;
    }

}

public class GraphNode
{
    public HashSet<GraphNode> Neighboors { get; set; } = [];
    public int Val { get; set; }
}

public static class GraphsSolution
{

    public class GraphNodeVisitAll
    {
        public HashSet<GraphNodeVisitAll> Neighboors { get; set; } = [];
        public int Val { get; set; }
        public List<int> Keys { get; set; } = [];
    }

    public static bool CanVisitAllRooms(List<List<int>> rooms)
    {
        Dictionary<int, GraphNodeVisitAll> dict = new();

        foreach (var (roomKeys, i) in rooms.Select((it, i) => (it, i)))
        {
            if (dict.TryGetValue(i, out var curr) is false)
            {
                curr = new GraphNodeVisitAll()
                {
                    Val = i,
                    Keys = [.. roomKeys],
                };
                dict.Add(i, curr);
            }

            if (i > 0 && dict.TryGetValue(i - 1, out var prev))
            {
                curr.Neighboors.Add(prev);
                prev.Neighboors.Add(curr);
            }
        }

        var keys = new HashSet<int>();
        var visited = new HashSet<GraphNodeVisitAll>();

        var queue = new Queue<GraphNodeVisitAll>();
        queue.Enqueue(dict.First().Value);

        while (queue.TryDequeue(out var node))
        {
            foreach (var key in node.Keys)
            {
                keys.Add(key);
            }

            visited.Add(node);

            foreach (var key in node.Keys)
            {
                if (visited.Contains(dict[key]))
                {
                    continue;
                }

                queue.Enqueue(dict[key]);

            }
        }

        return visited.Count == rooms.Count;
    }
}
