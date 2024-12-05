# Advent Of Code

## Description[.gitignore](.gitignore)
This project is a C# implementation of the challenges offered by the [Advent Of Code](https://adventofcode.com) 
event. The goal of this project is to provide efficient and creative solutions for 
each daily problem while exploring and practicing various programming concepts.

## Installation

```shell
git clone https://https://github.com/ZoSand/AoC
```
[.gitignore](.gitignore)
## Dependencies

- .NET 8 SDK
- C# 12 compiler
- a CSProj compatible IDE (e.g. Jetbrains Rider/Visual Studio with appropriate workloads)

## How it works

When you start the program, the entry file lists every class derived from `AoC.Common.SolverBase`.
It then executes each solver method one by one based on the day attributes (`DayAttributes`).

Due to the login requirement and because the input is fetched directly from the Advent Of Code website,
you need to specify your session cookie in a `.env` file located next to the executable:

```env
AOC_SESSION_COOKIE=your_cookie_here
```

## Example of a Solver

```csharp
using AoC.Common;

namespace AoC._2014;

public class Solver() : SolverBase(2014)
{
    [Day(1, 1)]
    public string Day1_1(List<string> lines)
    {
        return "ok";
    }

    [Day(1, 2)]
    public string Day1_2(List<string> lines)
    {
        return "yes";
    }
}
```
Example output:
```
+---------------------+
| Solver 2014:        |
+-----+------+--------+
| Day | Part | Output |
+-----+------+--------+
| 01  |  01  | ok     |
| 01  |  02  | yes    |
+-----+------+--------+
```