using System.Collections.Generic;
using System.Diagnostics;
using TracerImplementation.Interfaces;

namespace TracerImplementation
{
    public sealed class Tracer :ITracer
    {
        private readonly List<TraceResult> _testsResults=new List<TraceResult>();
        private static Tracer _instance = null;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private Tracer(){}

        public static Tracer GetInstance()
        {
            return _instance ?? (_instance = new Tracer());
        }



        public TraceResult GetTraceResult()
        {
            var stackTrace = new StackTrace(true);
            var stackFrame = stackTrace.GetFrame(1);

            var traceResult=new TraceResult();
            var declaringType = stackFrame.GetMethod().DeclaringType;
            if (declaringType != null)
            traceResult.ClassName = declaringType.Name;
            traceResult.MethodName = stackFrame.GetMethod().Name;
            traceResult.NumberOfParam = stackFrame.GetMethod().GetParameters().Length;
            traceResult.TestTime = _stopwatch.ElapsedMilliseconds;
            _testsResults.Add(traceResult);

            return traceResult;

        }



        public void StartTrace()
        {
            _stopwatch.Start();
        }

        public void StopTrace()
        {
            _stopwatch.Stop();
           
        }



        public List<TraceResult> GetTraceList()
        {
            return _testsResults;
        }
    }
}
