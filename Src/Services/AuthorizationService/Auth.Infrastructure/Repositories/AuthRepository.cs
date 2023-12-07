using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Application.Ports.Repositories;
using Auth.Domain;

namespace Auth.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private List<User> Users { get; set; } = new();

    public AuthRepository()
    {
    }

    public async Task<User> GetUserByUserId(Guid userId)
    {
        return Users.SingleOrDefault(e => e.Id == userId);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(e => e.Email == email);
    }

    public async Task UpdateUser(User user)
    {
        // логика обновления
    }

    public async Task CreateUser(User user)
    {
        Users.Add(user);
    }
}