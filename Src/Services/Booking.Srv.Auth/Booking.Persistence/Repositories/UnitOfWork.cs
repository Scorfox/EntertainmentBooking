using Booking.Application.Repositories;
using Booking.Persistence.Context;

namespace Booking.Persistence.Repositories;

public class UnitOfWork(DataContext context) : IUnitOfWork
{
    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}