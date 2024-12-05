using System.Reflection;
using System.Text;

namespace AoC.Common;

public class SolverBase
{
    public int Year { get; private init; }
    
    //TODO: format output data into a table
    public string Output => FormatOutput();

    private readonly List<MethodInfo> _methods;
    private readonly Dictionary<DayAttribute, string> _results = new();

    protected SolverBase(int year)
    {
        Year = year;

        _methods = GetType()
            .GetMethods(BindingFlags.Instance | 
                        BindingFlags.Public |
                        BindingFlags.NonPublic)
            .Where(m => m.GetCustomAttributes(typeof(DayAttribute), false).Length != 0)
            .Where(m => m.ReturnType == typeof(string) && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(List<string>))
            .OrderBy(m =>
            {
                var attr = (DayAttribute)m.GetCustomAttributes(typeof(DayAttribute), false).First();
                return attr.Day * 24 + attr.Part;
            })
            .ToList();
    }

    public void Solve()
    {
        _methods.ForEach(method =>
        {
            var attr = (DayAttribute)method.GetCustomAttributes(typeof(DayAttribute), false).First();
            try
            {
                var input =  Api.GetInput(Year, attr.Day).Split("\n").ToList();
                _results.Add(attr, $"{method.Invoke(this, [input])}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
            }
        });
    }

    private string FormatOutput()
    {
        //find the longest line
        var longest = _results.Values.Select(s => s.Length).Max();
        if (longest < 6)
        {
            longest = 6;
        }
        StringBuilder sb = new();
        sb.AppendLine($"+{new string('-', longest+15)}+");
        sb.AppendLine($"| Solver {Year}:{new string(' ', longest + 2)}|");
        sb.AppendLine($"+-----+------+-{new string('-', longest)}-+");
        sb.AppendLine($"| Day | Part | Output{new string(' ', longest - 5)}|");
        sb.AppendLine($"+-----+------+-{new string('-', longest)}-+");
        foreach (var keyValuePair in _results)
        {
            sb.AppendLine($"| {keyValuePair.Key.Day:00}  |  {keyValuePair.Key.Part:00}  | {keyValuePair.Value}{new string(' ', longest - keyValuePair.Value.Length)} |");
        }
        sb.AppendLine($"+-----+------+-{new string('-', longest)}-+");

        return sb.ToString();
    }
}