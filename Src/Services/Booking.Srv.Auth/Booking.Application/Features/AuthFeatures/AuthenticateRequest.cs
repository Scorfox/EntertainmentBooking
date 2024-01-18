using MediatR;

namespace Booking.Application.Features.AuthFeatures;

public sealed record AuthenticateRequest : IRequest<(bool Success, string? RoleName)>
{
    public string Email { get; set; }
    public string Password { get; set; }
}