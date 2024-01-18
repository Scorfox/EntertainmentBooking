using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using Booking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
    
    public Task<User?> FindByEmail(string email, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}