using System;
using System.Globalization;

public class DayTwo : Puzzle
{
	private enum OpponentMove
	{
		None,
		Rock,
		Paper,
		Scissors,
	}

    private enum PlayerMove
    {
		None,
        Rock,
        Paper,
        Scissors,
	}

	private enum Outcome
	{
		Lose,
		Draw = 3,
		Win = 6,
	}

    public DayTwo(string file) : base(file)
	{
	}

	public override string Compute()
	{
		base.Compute();

		int total = 0;

		foreach (string line in input)
		{
			total += Match(GetOpponentMove(line[0]), GetOutcome(line[2]));
		}

		return total.ToString();
	}

	private int Match (OpponentMove oMove, PlayerMove pMove)
	{
		return (int)pMove + (int)GetOutcome(oMove, pMove);
	}

	private Outcome GetOutcome(OpponentMove oMove, PlayerMove pMove)
	{
        if ((int)oMove == (int)pMove) return Outcome.Draw;

        if (pMove == PlayerMove.Rock && oMove == OpponentMove.Scissors ||
            pMove == PlayerMove.Paper && oMove == OpponentMove.Rock ||
            pMove == PlayerMove.Scissors && oMove == OpponentMove.Paper)
        {
			return Outcome.Win;
        }

        return Outcome.Lose;
    }

    private int Match(OpponentMove oMove, Outcome outCome)
    {
        return (int)CalculateMove(oMove, outCome) + (int)outCome;
    }

    private PlayerMove CalculateMove (OpponentMove oMove, Outcome outCome)
	{
		if (outCome == Outcome.Draw)
		{
			return (PlayerMove)oMove;
		}
		if (outCome == Outcome.Lose)
		{
			switch (oMove)
			{
				case OpponentMove.Rock:
					return PlayerMove.Scissors;
				case OpponentMove.Paper:
					return PlayerMove.Rock;
				case OpponentMove.Scissors:
					return PlayerMove.Paper;
				default:
					break;
			}
		}
        if (outCome == Outcome.Win)
        {
            switch (oMove)
            {
                case OpponentMove.Rock:
                    return PlayerMove.Paper;
                case OpponentMove.Paper:
                    return PlayerMove.Scissors;
                case OpponentMove.Scissors:
					return PlayerMove.Rock;
                default:
                    break;
            }
        }

		return PlayerMove.None;
    }

	private OpponentMove GetOpponentMove(char c)
	{
		if (c == 'A') return OpponentMove.Rock;
		if (c == 'B') return OpponentMove.Paper;
		if (c == 'C') return OpponentMove.Scissors;
		return OpponentMove.None;
	}

	private PlayerMove GetPlayerMove(char c)
	{
        if (c == 'X') return PlayerMove.Rock;
        if (c == 'Y') return PlayerMove.Paper;
        if (c == 'Z') return PlayerMove.Scissors;
        return PlayerMove.None;
    }

	private Outcome GetOutcome(char c)
	{
        if (c == 'X') return Outcome.Lose;
        if (c == 'Y') return Outcome.Draw;
        if (c == 'Z') return Outcome.Win;
        return Outcome.Lose;
    }
}
