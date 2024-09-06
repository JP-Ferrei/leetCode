using neetcode.Problems;

namespace neetCodeTest.Problems;

[TestFixture]
public class SlidingWindowTests
{
    [TestCase("zxyzxyz", 3)]
    [TestCase("xxxx", 1)]
    [TestCase("pwwkew", 3)]
    [TestCase("aab", 2)]
    [TestCase("dvdf", 3)]
    public void LengthOfLongestSubstringTest(string input, int expected)
    {
        var outPut = SlidingWindow.LengthOfLongestSubstring(input);

        Assert.That(outPut, Is.EqualTo(expected));
    }

    [TestCase("XYYX", 2, 4)]
    [TestCase("AAABABB", 1, 5)]
    [TestCase("AABABBA", 1, 4)]
    [TestCase("BAAA", 0, 3)]
    public void CharacterReplacementTest(string inputString, int inputNumber, int expected)
    {
        var outPut = SlidingWindow.CharacterReplacement(inputString, inputNumber);

        Assert.That(outPut, Is.EqualTo(expected));
    }

    [TestCase("ab", "lecabee", true)]
    [TestCase("abc", "lecaabee", false)]
    public void CheckInclusionTest(string inputString, string inputString2, bool expected)
    {
        var outPut = SlidingWindow.CheckInclusion(inputString, inputString2);

        Assert.That(outPut, Is.EqualTo(expected));
    }

    [TestCase("OUZODYXAZV", "XYZ", "YXAZ")]
    [TestCase("xyz", "xyz", "xyz")]
    public void CheckInclusionTest(string inputString, string inputString2, string expected)
    {
        var outPut = SlidingWindow.MinWindow(inputString, inputString2);

        Assert.That(outPut, Is.EqualTo(expected));
    }
}
