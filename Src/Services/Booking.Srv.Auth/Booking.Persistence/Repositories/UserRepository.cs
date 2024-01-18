using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using Booking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistence.Repositories;

public class UserRepository(DataContext context) : BaseRepository<User>(context), IUserRepository
{
    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return Context.Users.Include(e => e.Role).SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public Task<bool> HasAnyByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return Context.Users.AnyAsync(x => x.Email == email, cancellationToken);
    }
}