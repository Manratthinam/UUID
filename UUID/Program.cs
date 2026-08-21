using System.Diagnostics.CodeAnalysis;
using UUID;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.WriteLine("  Longest Increasing Subarray Finder");
        Console.WriteLine("  Enter 'quit' or 'exit' to stop.");
        Console.WriteLine("═══════════════════════════════════════════════════");

        while (true)
        {
            Console.Write("\nInput: ");
            string? line = Console.ReadLine();

            if (line is null || line.Trim().ToLower() is "quit" or "exit")
                break;

            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine("Please enter at least one integer.");
                continue;
            }

            try
            {
                string result = LongestSequesnce.FindLongestIncreasingSubsequence(line);
                Console.WriteLine($"Output: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Input must contain only integers separated by spaces.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: One or more values are too large for a 32-bit integer.");
            }
        }
    }
}
