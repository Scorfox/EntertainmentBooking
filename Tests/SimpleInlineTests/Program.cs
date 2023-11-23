using Base.Objects;

namespace SimpleInlineTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Check debugger display
            List<BaseEntity> be = new List<BaseEntity>();
            be.Add(new BaseEntity {Id = Guid.NewGuid(), IsDeleted = false});
            Console.WriteLine("Hello, World!");
        }
    }
}