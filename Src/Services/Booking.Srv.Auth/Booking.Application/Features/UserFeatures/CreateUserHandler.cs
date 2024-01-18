using AutoMapper;
using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.Application.Features.UserFeatures;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);
        _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}