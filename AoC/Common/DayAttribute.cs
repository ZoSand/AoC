namespace AoC.Common;

public class DayAttribute( int day, int part) : System.Attribute
{
    public int Day
    {
        get;
        private init;
    } = day;
    
    public int Part
    {
        get;
        private init;
    } = part;
}