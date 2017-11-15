using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tracer.Interfaces;


namespace Trace
{
    public sealed class Tracer: ITracer
    {
        private static Tracer instance = null;

        private Tracer() { }

        public static Tracer GetInstance()
        {
            if (instance == null)
            {
                instance = new Tracer();
            }
            return instance;
        }

        Timer getTime = new Timer();
        public void StartTrace()
        {

            getTime.Start();
        }

        public void StopTrace()
        {
            getTime.Stop();
            
        }

        public TraceReult GeTraceReult()
        {
            getTime.GetLifetimeService();
            
            return null;
        }
    }
}
