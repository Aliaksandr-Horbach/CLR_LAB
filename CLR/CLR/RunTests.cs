using System.Diagnostics;
using TracerImplementation;

namespace CLR
{
    public class RunTests
    {

        public WritedInformation Run()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var testMethods = new TestMethods();
            testMethods.Test1();
            testMethods.Test2();
            testMethods.Test3();

            stopwatch.Stop();
            var testsTime = stopwatch.ElapsedMilliseconds;
            var testResults = Tracer.GetInstance().GetTraceList();

            var testsInformation = new WritedInformation(testsTime, testResults);
            return testsInformation;
        }
    }
}
