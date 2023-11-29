namespace Core;

internal class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        
        var application = builder.Build();

        application.Run();
    }
}
