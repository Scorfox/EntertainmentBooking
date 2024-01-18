using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using Booking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Persistence.Repositories;

public class RoleRepository(DataContext dataContext) : IRoleRepository
{
    public async Task<Role> GetByNameAsync(string name, CancellationToken token = default)
    {
        return await dataContext.Roles.SingleAsync(r => r.Name == name, token);
    }
}