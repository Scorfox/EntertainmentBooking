using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Booking.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
