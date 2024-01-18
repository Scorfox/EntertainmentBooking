namespace Booking.WebAPI.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(string email);
}