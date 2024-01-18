using Booking.Auth.Srv.Data.Common;

namespace Booking.Auth.Srv.Data.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    
    public string PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
}