using System;
using System.IO;

public class DayOne : Puzzle
{
	public DayOne(string file) : base(file)
	{
		
	}

	public override string Compute()
	{
		base.Compute();

        List<int> topCals = new List<int>();
        int topCalCount = 3;

        for (int i = 0; i < topCalCount; i++)
        {
            topCals.Add(0);
        }

        int runningCal = 0;

        foreach (string line in input)
        {
            if (line.Length == 0)
            {
                topCals.Sort();
                if (runningCal > topCals[0])
                {
                    topCals[0] = runningCal;
                }
                
                runningCal = 0;
            }
            else
            {
                runningCal += Int32.Parse(line);
            }
        }

        int output = 0;

        foreach (int cal in topCals)
        {
            output += cal;
        }

        return output.ToString();
    }
}
