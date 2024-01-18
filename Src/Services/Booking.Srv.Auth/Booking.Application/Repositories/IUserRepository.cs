using Booking.Auth.Srv.Data.Entities;

namespace Booking.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email, CancellationToken token);
    Task<bool> HasAnyByEmailAsync(string email, CancellationToken token);
}