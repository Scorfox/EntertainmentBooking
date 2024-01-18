using AutoMapper;
using Booking.Auth.Srv.Data.Entities;

namespace Booking.Application.Features.UserFeatures;


public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}