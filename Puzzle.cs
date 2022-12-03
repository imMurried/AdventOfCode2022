using System;

public abstract class Puzzle
{
    protected string path = Environment.CurrentDirectory;
	protected string filename;
    protected List<string> input;


    public Puzzle(string file)
	{
        filename = file;
	}

	public virtual string Compute()
	{
        if (!LoadData())
        {
            return "Failed To Load: " + filename;
        }

        return "No Output";
	}

    protected virtual bool LoadData()
    {
        input = new List<string>();
        try
        {
            input.AddRange(File.ReadAllLines(path + "/" + filename));
        }
        catch
        {
            return false;
        }

        return true;
    }
}
