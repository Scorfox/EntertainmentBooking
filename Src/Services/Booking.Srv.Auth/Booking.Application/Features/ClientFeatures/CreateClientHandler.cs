using AutoMapper;
using Booking.Application.Common;
using Booking.Application.Common.Exceptions;
using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.Application.Features.ClientFeatures;

public sealed class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateClientHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
    {
        if (await _userRepository.HasAnyByEmailAsync(request.Email, cancellationToken))
            throw new BadRequestException($"User with {request.Email} already exists");
            
        var user = _mapper.Map<User>(request);
        user.Role = (await _roleRepository.GetByNameAsync(Roles.Client, cancellationToken))!;
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);
        
        _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateClientResponse>(user);
    }
}