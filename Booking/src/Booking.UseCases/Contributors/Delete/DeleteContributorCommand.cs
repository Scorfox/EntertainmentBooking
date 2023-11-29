using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Booking.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
