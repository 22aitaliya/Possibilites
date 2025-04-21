namespace Possibilities;

public class qol
{
    public static string deepCheckOfDataType(string mSub)
    {
        Console.WriteLine("Removing whitespace for checker to properly funtion...");
        string sub = mSub.Replace(" ", "");
        Console.WriteLine($"Removed whitepace from {mSub} to {sub}");
        Console.WriteLine($"Running deep checker for  proper datatype of sub {sub}...");
        bool isMadeUpOfOnlyDigitsOrDecimal = false;
        foreach (char c in sub)
        {
            if (!(char.IsDigit(c) || c == '.'))
            {
                break;
            }

            if (c == sub[sub.Length - 1])
            {
                isMadeUpOfOnlyDigitsOrDecimal = true;
            }
        }
        if (!isMadeUpOfOnlyDigitsOrDecimal)
        {
            Console.WriteLine($"Sub {sub} is given datatype string");
            return "string";
        }
        if (sub.Contains('.'))
        {
            Console.WriteLine($"Sub {sub} is given datatype double");
            return "double";
        }
        Console.WriteLine($"Sub {sub} is given datatype int");
        return "int";
    }
}
