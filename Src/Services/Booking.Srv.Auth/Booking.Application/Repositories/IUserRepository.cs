using Booking.Auth.Srv.Data.Entities;

namespace Booking.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmail(string email, CancellationToken token);
}