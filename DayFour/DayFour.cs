using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayFour : Puzzle
{
    public DayFour(string file) : base(file)
    {
    }

    public override string Compute()
    {
        base.Compute();

        int countOverlaps = 0;

        foreach (string line in input)
        {
            string[] ranges = line.Split(',');
            int a = Int32.Parse(ranges[0].Split('-')[0]);
            int b = Int32.Parse(ranges[0].Split('-')[1]);
            int x = Int32.Parse(ranges[1].Split('-')[0]);
            int y = Int32.Parse(ranges[1].Split('-')[1]);

            //if (RangeContainsRange(a,b,x,y) || RangeContainsRange(x,y,a,b))
            if (RangesOverlap(a,b,x,y))
                countOverlaps++;
        }

        return countOverlaps.ToString();
    }

    private bool RangeContainsRange(int a, int b, int x, int y)
    {
        return (x >= a && y <= b);
    }

    private bool RangesOverlap(int a, int b, int x, int y)
    {
        return (x >= a && x <= b) || (y >= a && y <= b) ||
            (a >= x && a <= y) || (b >= x && b <= y);
    }
}
