using System.Data;

namespace Possibilities;

public class stringTests
{
    public static List<string> getDictionary()
    {

        string filename = "/Users/Adi/RiderProjects/Possibilities/Possibilities/Oxford Dictionary.txt";
        List<string> words = new List<string>();
        StreamReader reader = new StreamReader(filename);
        Console.WriteLine($"Reading words from {filename}");
        string subWord = reader.ReadLine();
        do
        {
            words.Add(subWord);
            subWord = reader.ReadLine();

        } while (subWord != null);
        Console.WriteLine($"Read files from {filename}");
        reader.Close();
        return words;
    }

    public List<string> evaledList(string Fsub)
    {
        string sub = Fsub;
        List<string> dict = getDictionary();
        List<string> relevantWords = new List<string>();
        List<double> rWEval =  new List<double>();
        // Actual evaluating
        foreach (string word in dict)
        {
            double evalResult = eval(word, sub);
            if (evalResult > 0.95)
            {
                relevantWords.Add(word);
                rWEval.Add(evalResult);
            }
        }

        foreach (string word in relevantWords)
        {
            Console.Write($"{word} ");
        }
        return relevantWords;
    }

    public static double eval(string evaluatee, string evaluator)
    {
        
        if (evaluator.Length == 0 && evaluatee.Length == 0) return 1.0;
        if (evaluator.Length == 0 || evaluatee.Length == 0) return 0.0;
        if (evaluator == evaluatee) return 1.0;

        // --- Get Character Pairs (Bigrams) into Lists ---
        // Note: These lists might contain duplicate pairs if they exist in the strings
        List<string> evaluatorBigramsList = GetCharacterPairs(evaluator);
        List<string> evaluateeBigramsList = GetCharacterPairs(evaluatee);
        
        // there is something called a dice coeficcient we need to use (we need uniqueness to function)
        List<string> uniqueEvaluatorBigrams = evaluatorBigramsList.Distinct().ToList();
        List<string> uniqueEvaluateeBigrams = evaluateeBigramsList.Distinct().ToList();

        // .intersect gets the simaliar parts of the lists
        int uniquePairs = uniqueEvaluatorBigrams.Intersect(uniqueEvaluateeBigrams).Count();
        int totalUniquePairs = uniqueEvaluatorBigrams.Count() + uniqueEvaluateeBigrams.Count();
        if (totalUniquePairs == 0) 
        {
            return 0.0; 
        }

        // Apply the Dice Coefficient formula: (2 * Common Unique Pairs) / (Total Unique Pairs) <- I used AI to find out about this
        double similarity = (2.0 * uniquePairs) / totalUniquePairs;

        return similarity;
    }

    
    static List<string> GetCharacterPairs(string str)
    {
        List<string> pairs = new List<string>(); 
        if (str.Length < 2)
        {
            return pairs;
        }

        for (int i = 0; i < str.Length - 1; i++)
        {
            pairs.Add(str.Substring(i, 2)); // Add pairs to the list
        }
        return pairs;
    
    }
    // All variations of the words -------------------------------------------------------------------------------------
    
    public List<string> makeVariations(string sub)
    {
        Console.WriteLine("Testing for possible null or empty input");
        if (sub == null)
        {
            return new List<string>(); // Return empty list if input is null
        }
        if (sub.Length <= 1)
        {
            Console.WriteLine("Sub only has one value so variations is the same thing");
            return new List<string> { sub }; // Beacuse sub can only be one thing
        }

        char[] splitSub = sub.ToCharArray();
        List<string> allResults = new List<string>();
        
        makeVariations(splitSub, 0, allResults);

        Console.WriteLine("Variations done");
        return allResults.Distinct().OrderBy(s  => s).ToList(); // Order by basically just sorts by the string itself
    } 
    private static void makeVariations(char[] chars, int pos, List<string> results) 
    {
        if (pos == chars.Length - 1) { results.Add(new string(chars)); }
        else
        {
            // Recursive Step: Try swapping the current letter (at k) with every letter after it
            Console.WriteLine("Running recursive steps ");
            for (int i = pos; i < chars.Length; i++)
            {
                swap(ref chars[pos], ref chars[i]);
                makeVariations(chars, pos + 1, results);
                swap(ref chars[pos], ref chars[i]);
            }
        }
    }
   
    private static void swap(ref char a, ref char b)
    {
        if (a == b) return; // Skip swapping if letters are identical
        char temp = a;
        a = b;
        b = temp;
    }
}
