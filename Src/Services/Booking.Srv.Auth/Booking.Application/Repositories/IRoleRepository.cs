using Booking.Auth.Srv.Data.Entities;

namespace Booking.Application.Repositories;

public interface IRoleRepository
{
    public Task<Role> GetByNameAsync(string name, CancellationToken token = default);
}