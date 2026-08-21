# Longest Increasing Subarray Finder

A C# .NET console application that finds the **longest contiguous strictly increasing subarray** from a sequence of space-separated integers.

## Problem Definition

Given a string of integers separated by single spaces, find and return the longest contiguous subarray where each element is strictly greater than the previous. If multiple subarrays share the longest length, the **earliest** one is returned.

### Examples

| Input | Output |
|-------|--------|
| `6 1 5 9 2` | `1 5 9` |
| `6 2 4 6 1 5 9 2` | `2 4 6` *(tie → earliest wins)* |
| `6 2 4 3 1 5 9` | `1 5 9` |

---

## Project Structure

```
UUID/
├── UUID/                  ← Console application
│   ├── UUID.csproj
│   ├── Program.cs         ← Entry point (interactive & test-case modes)
│   └── LIS.cs             ← Core algorithm
├── UUID.Tests/            ← NUnit test project
│   ├── UUID.Tests.csproj
│   └── LISTests.cs
├── test-cases/            ← Put .txt input files here
├── outputs/               ← Auto-generated results go here
├── UUID.sln
└── README.md
```

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)

### Build

```bash
dotnet build
```

---

## Running the App

### Interactive Mode (default)

Enter sequences manually, one per prompt:

```bash
dotnet run --project UUID
```

```
═══════════════════════════════════════════════════
  Longest Increasing Subarray Finder
  Enter 'quit' or 'exit' to stop.
═══════════════════════════════════════════════════

Input: 6 1 5 9 2
Output: 1 5 9

Input: quit
```

### Test-Cases Mode

Reads every `.txt` file from `test-cases/`, prints each output to the console, and saves results to `outputs/`:

```bash
dotnet run --project UUID -- --test
```

```
═══════════════════════════════════════════════════
  Running 4 test case(s)...
═══════════════════════════════════════════════════

[test1]
  Input  : 6 1 5 9 2...
  Output : 1 5 9
  Saved  : outputs/test1_output.txt
...
```

#### Adding your own test cases

Place a `.txt` file in `test-cases/` with one integer sequence per line:

```
# test-cases/mytest.txt
6 1 5 9 2
6 2 4 6 1 5 9 2
```

---

## Running the Tests

```bash
dotnet test
```

All 14 tests should pass (11 provided test cases + 3 edge cases).

```
Passed!  - Failed: 0, Passed: 14, Skipped: 0
```

---

## Algorithm

The algorithm is **O(n) time, O(n) space**:

1. Scan left to right, tracking the current run start and length.
2. When `nums[i] > nums[i-1]`, extend the current run.
3. Otherwise, reset the current run at position `i`.
4. Update the best run only when the current run is **strictly longer** (preserves the earliest run on ties).

```csharp
// Core loop (simplified)
for (int i = 1; i < nums.Length; i++)
{
    if (nums[i] > nums[i - 1])
        currLen++;
    else
    {
        currStart = i;
        currLen = 1;
    }

    if (currLen > bestLen)
    {
        bestLen = currLen;
        bestStart = currStart;
    }
}
```

---

## Verifying the Solution

You can verify any of the 11 provided test cases:

```bash
dotnet run --project UUID -- --test
```

Outputs are saved to `outputs/` so you can diff them against the expected values in `code-test.md`.
