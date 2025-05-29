namespace HangFire_App.JobServices
{
    public class ScheduledJob
    {
        public string ClassName { get; set; } //نام کلاس
        public string MethodName { get; set; } //نام متد
        public TimeSpan ExecutionTime { get; set; } // مثل 10:30:00
    }
}
