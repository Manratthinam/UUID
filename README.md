# Longest Increasing Subarray Finder

A **.NET 9.0** console application that finds the longest **contiguous strictly increasing subarray** from a space-separated list of integers. The solution runs interactively in the terminal and is fully containerised with Docker.

---

## Table of Contents

- [Problem Statement](#problem-statement)
- [Algorithm](#algorithm)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Running Locally](#running-locally)
- [Running with Docker](#running-with-docker)
- [Running Tests](#running-tests)
- [Example Usage](#example-usage)
- [Test Coverage](#test-coverage)

---

## Problem Statement

Given a sequence of integers, find the **longest contiguous subarray** where every element is strictly greater than the previous one.

- If multiple subarrays share the same maximum length, the **earliest** one is returned.
- Input and output are both **space-separated integers**.

| Input          | Output  | Reason                        |
|----------------|---------|-------------------------------|
| `6 1 5 9 2`    | `1 5 9` | Length 3, starts at index 1   |
| `9 4 1 2 3`    | `1 2 3` | Length 3, starts at index 2   |
| `6 2 4 6 1 5 9 2` | `2 4 6` | Tie → earliest run wins  |
| `1 2 3 4 5`    | `1 2 3 4 5` | Entire array ascending   |
| `9 7 5 3 1`    | `9`     | All descending, length 1      |

---

## Algorithm

The core logic lives in [`UUID/LongestSequesnce.cs`](UUID/LongestSequesnce.cs) and runs in a single pass.

```
bestStart = 0, bestLen = 1
currStart = 0, currLen = 1

for i = 1 to n-1:
    if nums[i] > nums[i-1]:
        currLen++
    else:
        currStart = i
        currLen   = 1

    if currLen > bestLen:          // strict > preserves earliest on tie
        bestLen   = currLen
        bestStart = currStart

return nums[bestStart .. bestStart + bestLen - 1]
```

| Property        | Value |
|-----------------|-------|
| Time complexity | O(n)  |
| Space complexity| O(n) — output array |

---

## Project Structure

```
UUID/                          ← Solution root
├── UUID.sln                   ← Solution file
│
├── UUID/                      ← Console application
│   ├── UUID.csproj            ← Project file (.NET 9.0 Exe)
│   ├── Program.cs             ← Interactive REPL entry point
│   └── LongestSequesnce.cs    ← Core algorithm (static class)
│
├── UUID.Tests/                ← NUnit test project
│   ├── UUID.Tests.csproj      ← Project file (NUnit 4 / .NET 9.0)
│   └── LongestSequenceTest.cs ← 16 unit tests (provided + edge cases)
│
├── Dockerfile                 ← Multi-stage build (SDK → Runtime)
├── docker-compose.yml         ← Interactive container config
├── .dockerignore              ← Docker build exclusions
└── .gitignore                 ← Git exclusions
```

---

## Prerequisites

| Tool           | Version  | Required for          |
|----------------|----------|-----------------------|
| .NET SDK       | 9.0+     | Local build & test    |
| Docker Desktop | any      | Container run         |
| Docker Compose | v2+      | `docker-compose` cmds |

---

## Running Locally

### Build & Run

```powershell
# From the solution root
dotnet run --project UUID/UUID.csproj
```

### Build only

```powershell
dotnet build UUID.sln
```

---

## Running with Docker

### Option 1 — docker-compose (recommended for interactive use)

```powershell
# Build and attach (interactive mode)
docker-compose run --rm uuid-app
```

### Option 2 — docker build + run

```powershell
# Build the image
docker build -t uuid-app .

# Run interactively
docker run -it --rm uuid-app
```

> **Note:** The container is configured with `stdin_open: true` and `tty: true` in `docker-compose.yml` so the REPL accepts keyboard input.

### Stopping the container

Type `exit` or `quit` at the `Input:` prompt, or press <kbd>Ctrl+C</kbd>.

---

## Running Tests

```powershell
# Run all tests from the solution root
dotnet test UUID.sln

# With verbose output
dotnet test UUID.sln --logger "console;verbosity=detailed"

# With code coverage
dotnet test UUID.sln --collect:"XPlat Code Coverage"
```

---

## Example Usage

```
═══════════════════════════════════════════════════
  Longest Increasing Subarray Finder
  Enter 'quit' or 'exit' to stop.
═══════════════════════════════════════════════════

Input: 9 4 1 2 3
Output: 1 2 3

Input: 6 1 5 9 2
Output: 1 5 9

Input: 1 2 3 4 5
Output: 1 2 3 4 5

Input: 3 3 3
Output: 3

Input: hello
Error: Input must contain only integers separated by spaces.

Input: exit
```

---

## Test Coverage

The test suite in `UUID.Tests/LongestSequenceTest.cs` covers **16 test cases**:

### Provided Test Cases

| Test | Input (summary) | Expected Output |
|------|----------------|-----------------|
| TC1  | `6 1 5 9 2` | `1 5 9` |
| TC4  | 64-element sequence | `3862 16353 22813 28735` |
| TC5  | 128-element sequence | `11084 11970 24975 30922` |
| TC6  | 43-element sequence | `3808 3908 10386 19306` |
| TC7  | 300-element sequence | `125 1841 5882 18464 28317 31497` |
| TC8  | 19-element sequence | `9139 17687 25106 26202 27592 30937` |
| TC10 | Tie-break: earliest wins | `2 4 6` |
| TC11 | Tie-break: different runs | `1 5 9` |

### Edge Cases

| Test | Scenario |
|------|----------|
| Single element | Returns that element |
| All descending | Returns first element only |
| All ascending | Returns entire sequence |
| Equal elements (`3 3 3`) | Returns first element (not strictly increasing) |
| Empty string | Returns empty string |
| Whitespace-only string | Returns empty string |
| Two ascending elements | Returns both |
| Two descending elements | Returns first |
| Non-integer input | Throws `FormatException` |

---

## Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| `NUnit` | 4.2.2 | Test framework |
| `NUnit3TestAdapter` | 4.6.0 | VS / CLI test runner adapter |
| `Microsoft.NET.Test.Sdk` | 17.11.1 | Test host |
| `coverlet.collector` | 6.0.2 | Code coverage collection |
