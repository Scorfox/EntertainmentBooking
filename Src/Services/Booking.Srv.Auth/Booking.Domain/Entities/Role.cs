using Microsoft.AspNetCore.Identity;

namespace Booking.Auth.Srv.Data.Entities;

public class Role : IdentityRole<Guid>
{
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    public List<User> Users { get; set; }
}