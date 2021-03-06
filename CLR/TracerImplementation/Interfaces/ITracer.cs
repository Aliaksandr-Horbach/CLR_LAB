﻿namespace TracerImplementation.Interfaces
{
    internal interface ITracer
    {
        // method is called at the beginning of the method to be measured
        void StartTrace();

        // method is called at the end of the method to be measured
        void StopTrace();

        // returns an object with measurement results
        TraceResult GetTraceResult();
    }
}
