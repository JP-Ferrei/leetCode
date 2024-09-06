using System.Text;

namespace neetcode;

public static class Extensions
{
    public static void print<T>(this IEnumerable<T> x)
    {
        if (x.Count() > 0)
        {
            var a = string.Join(',', x);
            System.Console.WriteLine(a);
        }
    }
}
