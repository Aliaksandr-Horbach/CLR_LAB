using System.Collections.Generic;
using System.Diagnostics;
using TracerImplementation.Interfaces;

namespace TracerImplementation
{
    public sealed class Tracer :ITracer
    {    
        List<TraceResult> AllInformation=new List<TraceResult>();
        private static Tracer instance = null;
        Stopwatch stopwatch = new Stopwatch();

        private Tracer(){}

        public static Tracer GetInstance()
        {
            if (instance == null)
            {
                instance=new Tracer();
            }
            return instance;
        }



        public TraceResult GetTraceResult()
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);

            TraceResult traceResult=new TraceResult();
            var declaringType = stackFrame.GetMethod().DeclaringType;
            if (declaringType != null)
                traceResult.ClassName = declaringType.Name;
            traceResult.MethodName = stackFrame.GetMethod().Name;
            traceResult.QuantityOfParam = stackFrame.GetMethod().GetParameters().Length;
            traceResult.Time = stopwatch.ElapsedMilliseconds;
            AllInformation.Add(traceResult);

            return traceResult;

        }



        public void StartTrace()
        {
            stopwatch.Start();
        }

        public void StopTrace()
        {
            stopwatch.Stop();
           
        }



        public List<TraceResult> GetTraceList()
        {
            return AllInformation;
        }
    }
}
