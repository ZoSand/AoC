using System.Reflection;

using AoC.Common;

List<SolverBase> solvers = Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(SolverBase).IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false } && t != typeof(SolverBase))
    .Select(t => (SolverBase?)Activator.CreateInstance(t))
    .Where(s => s != null)
    .OrderBy(s => s!.Year)
    .ToList()!;

foreach (var solver in solvers)
{
    solver.Solve();
    Console.WriteLine(solver.Output);
}