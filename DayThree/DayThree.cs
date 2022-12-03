using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayThree : Puzzle
{

    public DayThree(string file) : base(file)
    {
    }

    public override string Compute()
    {
        base.Compute();

        int total = 0;

        for (int i = 0; i < input.Count; i+=3)
        {
            string longestSack = input[i];
            string sackOne = input[i + 1];
            string sackTwo = input[i + 2];

            if (sackOne.Length > longestSack.Length)
            {
                string temp = longestSack;
                longestSack = sackOne;
                sackOne = temp;
            }
            if (sackTwo.Length > longestSack.Length)
            {
                string temp = longestSack;
                longestSack = sackTwo;
                sackTwo = temp;
            }


            for (int j = 0; j < longestSack.Length; j++)
            {
                if (sackOne.Contains(longestSack[j]))
                {
                    if (sackTwo.Contains(longestSack[j]))
                    {
                        total += GetPriorityValue(longestSack[j]);
                        break;
                    }
                }
            }
        }

        return total.ToString();
    }

    private int GetPriorityValue(char c)
    {
        if ((int)c >= 97 && (int)c <= 122)
            return (int)c - 96;
        else if ((int)c >= 65 && (int)c <= 90)
            return (int)c - 38;
        return 0;
    }
}
