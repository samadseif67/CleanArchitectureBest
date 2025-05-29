namespace HangFire_App.JobServices
{
    public   class MyJobs
    {
        public   void MyJobMethod()
        {
            Console.WriteLine($"this work start {DateTime.Now}");
        }
        public void MyJobMethod2()
        {
            Console.Clear();
            Console.WriteLine($"samad this work start2 {DateTime.Now}");
        }
    }
}
