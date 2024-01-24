using Base.Contracts.RabbitMq.Events;
using Base.Objects.Helpers;
using Core.Helpers;
using MassTransit;
using SimpleInlineTests.Mock;

namespace SimpleInlineTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            var test = new RabbitMqPublisher();
            
            var user = Guid.NewGuid();
            var table = Guid.NewGuid();

            Console.Title = "TEST";
            Console.WriteLine($"User : {user}");
            
            Console.WriteLine("Auth...");

            test.UserAuthorized(user);

            Console.WriteLine($"Table : {table}");
            Console.WriteLine("Reserving...");

            test.UserSelectTable(user, table);

            Console.WriteLine("End...");
            Console.ReadLine();
        }
    }
}