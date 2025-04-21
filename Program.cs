using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

// AREAS WHERE WORK NEEDS TO BE DONE
// stringTests.eval 
namespace Possibilities;
using cs = Console;
using cv = Convert;
class Program
{
    static void Main(string[] args)
    {
        qol qol = new qol();
        string mSub = cs.ReadLine();
        
        switch (qol.deepCheckOfDataType(mSub))
        {
            case "string": 
                Console.WriteLine("mSub now has datatype of string"); 
                runStringTests(mSub);
                break;
            case "int":
                cv.ToInt32(mSub);
                Console.WriteLine("mSub now has datatype of int");
                break;
            case "double":
                cv.ToDouble(mSub);
                Console.WriteLine("mSub now has datatype of double");
                break;
            default:
                Console.WriteLine("mSub has no valid datatype so will remain as a string and run appropriate string tests");
                break;
        }
        
    }
    static void runStringTests(string sub)
    {
        Console.WriteLine();
        stringTests st = new stringTests();
        List<string> evaled = st.evaledList(sub);
        List<string> variations = st.makeVariations(sub);
        foreach (var x in variations)
        {
            Console.Write($"{x} ");
        }
    }
    static void runIntTests(int sub)
    {
        
    }
    static void runDoubleTests(double sub)
    {
        
    }
}
