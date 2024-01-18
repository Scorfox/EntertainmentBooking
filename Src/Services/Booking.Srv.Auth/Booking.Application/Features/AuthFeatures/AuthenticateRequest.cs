using MediatR;

namespace Booking.Application.Features.AuthFeatures;

public sealed record AuthenticateRequest : IRequest<bool>
{
    public string Email { get; set; }
    public string Password { get; set; }
}