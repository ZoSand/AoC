using System.Linq;
using AoC.Common;

namespace AoC._2024;

public class Solver() : SolverBase(2024)
{
    [Day(1, 1)]
    public string Day1_1(List<string> lines)
    {
        return lines
            .SelectMany(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(int.Parse)
            .Select((num, index) => new { num, index })
            .GroupBy(i => i.index % 2 == 0)
            .Select(g => g
                .OrderBy(i => i.num)
                .Select(i => i.num))
            .Aggregate((a, b) => a
                .Zip(b, (x, y) => Math.Abs(x - y)))
            .Sum()
            .ToString();

        return lines[0];
    }

    [Day(1, 2)]
    public string Day1_2(List<string> lines)
    {
        return lines
            .SelectMany(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(int.Parse)
            .Select((num, index) => new { num, index })
            .GroupBy(i => i.index % 2 == 0)
            .Select(g => g
                .OrderBy(i => i.num)
                .Select(i => i.num))
            .Aggregate((a, b) =>
                a.Select(x => b.Count(i => i == x) * x)
            )
            .Sum()
            .ToString();
    }
}