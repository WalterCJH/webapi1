namespace webapi1.Services
{
    public interface IMyService
    {
        string Name { get; set; }
        public string Execute();
    }

    public interface IMyServiceSingleton : IMyService
    {
    }

    public class MyService : IMyService, IMyServiceSingleton
    {
        public string Name { get; set; } = "WILL";
        public string Execute()
        {
            return this.Name;
        }
    }

    public class MyService2 : IMyService
    {
        public string Name { get; set; } = "WILL2";
        public string Execute()
        {
            return this.Name;
        }
    }
}