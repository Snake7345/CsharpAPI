namespace CsharpAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            var app = Startup.InitializeApp(args);



            app.Run();
        }
    }
}