using NUnit.Framework;
using UUID;

namespace UUID.Tests;

[TestFixture]
public class LongestSequenceTest
{
    // ── Provided test cases ────────────────────────────────────────────────

    [Test]
    [Description("Test Case 1 – basic short sequence")]
    public void TestCase1_BasicShortSequence()
    {
        string input    = "6 1 5 9 2";
        string expected = "1 5 9";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 4 – medium sequence")]
    public void TestCase4_MediumSequence()
    {
        string input    = "923 11613 30483 19569 24201 13461 1189 30793 8848 16914 16053 21700 22116 3852 20909 5231 31469 3862 16353 22813 28735 4421 3618 32303 9932 31892 7823 22547 28888 11143 11695 3339 2094 11023 9661 27440 7186 24750 15427 24502 31606 23515 3563 29553 12145 22184 11409 28824 6636 10658 21404 5578 27807 14073 13967 31310 3132 4321 7643 1951 13289 24375 17912 11304";
        string expected = "3862 16353 22813 28735";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 5 – sequence with early run")]
    public void TestCase5_SequenceWithEarlyRun()
    {
        string input    = "27892 18536 13491 11084 11970 24975 30922 11945 15113 27101 1974 31902 2623 21822 11720 30730 23635 27193 17527 19799 16794 30488 8953 28856 12300 25162 32016 20910 30896 6661 9255 26577 12629 10032 24221 31949 26243 26495 18785 22443 10673 13024 30655 11602 20408 28694 17785 31309 29576 23715 3866 10702 4378 3052 17543 11763 19622 24984 2519 27977 14869 2873 23140 10639 14521 15662 25122 17340 14140 14024 304 323 29654 20907 11693 13973 3267 8311 10189 31463 29941 24744 13356 18742 8454 17339 20578 12937 112 21395 5591 1399 5888 30234 16089 3816 19080 21547 491 22560 14549 10160 14176 1529 10720 13575 32041 15727 29256 29611 19692 12642 23040 10768 14422 15768 23365 206 16305 13058 19924 20738 30393 14656 21081 12785 27563 26982";
        string expected = "11084 11970 24975 30922";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 6 – sequence with mid run")]
    public void TestCase6_SequenceWithMidRun()
    {
        string input    = "4650 2543 1184 1537 10037 9856 18201 29781 16440 8124 15835 23273 21808 2808 28925 2374 19 16546 9279 3323 19905 14701 20381 6116 6968 18094 1572 7084 21256 10758 16133 16017 7944 20546 13544 3431 25158 13183 20354 3808 3908 10386 19306";
        string expected = "3808 3908 10386 19306";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 7 – sequence with run in the middle")]
    public void TestCase7_RunInMiddle()
    {
        string input    = "8618 18885 18979 13930 25375 7000 16083 6748 30343 5025 28080 14559 17139 15042 18018 27339 1639 15611 20793 12289 14035 6093 14273 26028 28484 8799 15255 12743 15708 29984 3964 18400 25344 29870 18088 27419 24656 1015 20064 20857 23004 8606 9675 19546 12052 29856 18434 23105 21761 3127 31846 1496 18739 22270 310 13876 12539 5462 17505 21593 30938 19209 7832 27137 2104 29742 17576 7577 23897 333 25351 12173 9614 24259 6060 23749 9640 2919 15908 19056 1714 621 16867 24320 23264 31883 27352 11381 28354 19547 22596 20447 15037 23041 7627 27166 2236 525 14028 5613 8739 23459 17390 32543 6661 10713 18171 32551 1942 31840 20722 25310 17635 17255 22103 15745 1472 23228 7630 27897 23298 20532 31976 13152 30191 26958 22333 2496 16371 11283 5051 4126 6805 28480 31805 16055 23464 13735 15199 15497 22982 22739 27793 32533 7418 18155 29291 5988 1981 22488 1857 20552 3108 32170 15350 484 16727 21560 22805 15982 27973 21511 22045 15412 22166 11374 23325 8413 29409 2295 129 4594 17696 17927 16684 11933 97 22722 21191 22192 17086 28201 22616 25320 31886 1413 8982 12916 22493 2569 30076 12721 13338 12211 31900 15928 2576 6003 29622 3098 19480 32399 9737 28778 5772 32070 17129 13564 17534 6324 14354 22893 15530 11253 1596 25955 2730 27789 17391 12310 6249 3591 17049 16656 7130 18653 2526 11825 3306 18584 7471 6901 14259 17720 16286 15610 16114 19414 10736 2492 8891 31368 26356 29091 8043 13189 18964 19521 30943 2954 13354 22996 1507 30588 6805 32275 4077 32078 1163 6183 23308 27685 29360 7159 27163 24506 25832 20648 21306 4864 29290 22628 14463 17928 10263 25947 14568 15137 8457 16392 28052 3907 3438 694 18227 29102 7063 11842 24508 32462 30540 31778 5214 16994 21347 4518 31672 9437 12689 30846 3148 18444 23679 125 1841 5882 18464 28317 31497";
        string expected = "125 1841 5882 18464 28317 31497";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 8 – run at start")]
    public void TestCase8_RunAtStart()
    {
        string input    = "11509 13451 983 15160 24317 10470 12978 2341 27378 5127 29573 12870 22021 9139 17687 25106 26202 27592 30937";
        string expected = "9139 17687 25106 26202 27592 30937";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 10 – tie-breaking: earliest run wins")]
    public void TestCase10_TieBreakingEarliestWins()
    {
        string input    = "6 2 4 6 1 5 9 2";
        string expected = "2 4 6";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    [Test]
    [Description("Test Case 11 – tie-breaking with different runs")]
    public void TestCase11_TieBreakingDifferentRuns()
    {
        string input    = "6 2 4 3 1 5 9";
        string expected = "1 5 9";
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(input), Is.EqualTo(expected));
    }

    // ── Edge cases ─────────────────────────────────────────────────────────

    [Test]
    [Description("Single element input returns that element")]
    public void SingleElement_ReturnsThatElement()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("42"), Is.EqualTo("42"));
    }

    [Test]
    [Description("All descending returns first element")]
    public void AllDescending_ReturnsFirstElement()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("9 7 5 3 1"), Is.EqualTo("9"));
    }

    [Test]
    [Description("All ascending returns the entire sequence")]
    public void AllAscending_ReturnsWholeSequence()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("1 2 3 4 5"), Is.EqualTo("1 2 3 4 5"));
    }

    [Test]
    [Description("Equal elements are not increasing")]
    public void EqualElements_NotIncreasing()
    {
        // 3 3 3 — no pair strictly increases, so each run is length 1
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("3 3 3"), Is.EqualTo("3"));
    }

    [Test]
    [Description("Empty string returns empty string")]
    public void EmptyString_ReturnsEmpty()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence(""), Is.EqualTo(string.Empty));
    }

    [Test]
    [Description("Whitespace-only string returns empty string")]
    public void WhitespaceOnly_ReturnsEmpty()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("   "), Is.EqualTo(string.Empty));
    }

    [Test]
    [Description("Two element ascending")]
    public void TwoElementsAscending_ReturnsBoth()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("1 2"), Is.EqualTo("1 2"));
    }

    [Test]
    [Description("Two element descending returns first")]
    public void TwoElementsDescending_ReturnsFirst()
    {
        Assert.That(LongestSequesnce.FindLongestIncreasingSubsequence("5 3"), Is.EqualTo("5"));
    }

    [Test]
    [Description("Non-integer input throws FormatException")]
    public void NonIntegerInput_ThrowsFormatException()
    {
        Assert.Throws<FormatException>(() =>
            LongestSequesnce.FindLongestIncreasingSubsequence("1 two 3"));
    }
}
