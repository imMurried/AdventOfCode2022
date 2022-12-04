
List<Puzzle> puzzles = new List<Puzzle>();

puzzles.Add(new DayOne("d1_input.txt"));
puzzles.Add(new DayTwo("d2_input.txt"));
puzzles.Add(new DayThree("d3_input.txt"));
puzzles.Add(new DayFour("d4_input.txt"));

int count = 1;
foreach (Puzzle puzzle in puzzles)
{
    string output = puzzle.Compute();
    Console.WriteLine("Day " + count + ": " + output);
    count++;
}
