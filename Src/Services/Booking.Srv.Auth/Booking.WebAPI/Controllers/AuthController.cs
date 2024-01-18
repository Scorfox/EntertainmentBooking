using Booking.Application.Features.AuthFeatures;
using Booking.Application.Features.UserFeatures;
using Booking.WebAPI.Models;
using Booking.WebAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebAPI.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthController(IJwtTokenGenerator jwtTokenGenerator, IMediator mediator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<TokenDto>> Login(AuthenticateRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return response.Success ? Ok(_jwtTokenGenerator.GenerateToken(request.Email, response.RoleName)) : Unauthorized();
    }
}