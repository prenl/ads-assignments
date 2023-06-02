using assignment6.Search;
using NUnit.Framework;
using NUnitLite;

namespace assignment6;

public class Program
{

    static int Main(string[] args)
    {
        var testAssembly = typeof(Program).Assembly;
        var testRunner = new AutoRun(testAssembly);
        var testResult = testRunner.Execute(args);
        return testResult;
    }

}