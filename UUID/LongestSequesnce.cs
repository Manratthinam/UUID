namespace UUID;

/// <summary>
/// Finds the longest contiguous strictly increasing subarray from a
/// space-separated string of integers.
/// If multiple subarrays share the longest length, the earliest one is returned.
/// Time complexity: O(n). Space complexity: O(n).
/// </summary>
public static class LongestSequesnce
{
    /// <summary>
    /// Finds the longest contiguous strictly increasing subarray.
    /// </summary>
    /// <param name="input">Space-separated integers as a string.</param>
    /// <returns>Space-separated result, or empty string for empty input.</returns>
    /// <exception cref="FormatException">Thrown when input contains non-integer values.</exception>
    public static string FindLongestIncreasingSubsequence(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        int[] nums = input.Trim()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

        if (nums.Length == 0)
            return string.Empty;

        int bestStart = 0, bestLen = 1;
        int currStart = 0, currLen = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                currLen++;
            }
            else
            {
                currStart = i;
                currLen = 1;
            }

            // Only update best when strictly longer (preserves earliest on tie)
            if (currLen > bestLen)
            {
                bestLen = currLen;
                bestStart = currStart;
            }
        }

        return string.Join(" ", nums.Skip(bestStart).Take(bestLen));
    }
}
