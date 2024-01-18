﻿using AutoMapper;
using Booking.Application.Common;
using Booking.Application.Common.Exceptions;
using Booking.Application.Repositories;
using Booking.Auth.Srv.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.Application.Features.UserFeatures;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (!Roles.GetAllRolesWithIds().Keys.Contains(request.RoleName))
            throw new NotFoundException($"Role with name {request.RoleName} not found");
        
        if (await _userRepository.HasAnyByEmailAsync(request.Email, cancellationToken))
            throw new BadRequestException($"User with {request.Email} already exists");
            
        var user = _mapper.Map<User>(request);
        
        var role = await _roleRepository.GetByNameAsync(request.RoleName, cancellationToken);
        
        user.Role = role;
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);
        
        _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}