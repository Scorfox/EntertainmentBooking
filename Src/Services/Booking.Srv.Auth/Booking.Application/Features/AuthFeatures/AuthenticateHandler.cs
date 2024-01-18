using AutoMapper;
using Booking.Application.Common.Exceptions;
using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.Application.Features.AuthFeatures;

public sealed class AuthenticateHandler : IRequestHandler<AuthenticateRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthenticateHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmail(request.Email, cancellationToken);

        if (user == null)
            throw new NotFoundException($"User with email {request.Email} not found");
        
        var result = new PasswordHasher<User>().VerifyHashedPassword
            (user, user.PasswordHash, request.Password);

        return result == PasswordVerificationResult.Success;
    }
}