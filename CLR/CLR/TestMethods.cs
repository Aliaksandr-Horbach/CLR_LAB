using TracerImplementation;

namespace CLR
{
    internal class TestMethods
    {
        //private Tracer tracer=new Tracer();
        public Tracer Tracer { get; set; }
        
        
        public void Test1()
         {
            Tracer.GetInstance().StartTrace();

            for (int i = 0; i < 10000000; i++)
             {
             }

             Tracer.GetInstance().StopTrace();
             Tracer.GetInstance().GetTraceResult();

         }

        public void Test2()
        {
            Tracer.GetInstance().StartTrace();

            for (int i = 0; i < 10000000; i++)
            {
            }

            Tracer.GetInstance().StopTrace();
            Tracer.GetInstance().GetTraceResult();

        }
        public void Test3()
        {
            Tracer.GetInstance().StartTrace();
            Test2();
            for (int i = 0; i < 10000000; i++)
            {
            }

            Tracer.GetInstance().StopTrace();
            Tracer.GetInstance().GetTraceResult();

        }



    }
}
