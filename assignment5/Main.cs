using assignment5;

using NUnit.Framework;
using NUnitLite;

namespace assingment5;

class Program
{
    static int Main(string[] args)
    {
        var testAssembly = typeof(Program).Assembly;
        var testRunner = new AutoRun(testAssembly);
        var testResult = testRunner.Execute(args);
        return testResult;
    }
}