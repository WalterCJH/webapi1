namespace webapi1.Services
{
    public interface IMyFactory
    {
        string Name { get; set; }

        string Execute();
    }

    public class MyFactory : IMyFactory
    {
        public string Name { get; set; } = "Factory";
        public string Execute()
        {
            return this.Name;
        }
    }
    
    public class MyFactory2 : IMyFactory
    {
        public string Name { get; set; } = "Factory2";
        public string Execute()
        {
            return this.Name;
        }
    }
}