using Booking.Application.Features.AuthFeatures;
using Booking.Application.Features.UserFeatures;
using Booking.WebAPI.Models;
using Booking.WebAPI.Services;
using MediatR;
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
    public async Task<ActionResult<TokenDto>> Login(AuthenticateRequest request,
        CancellationToken cancellationToken)
    {
        var authSuccess = await _mediator.Send(request, cancellationToken);
        return authSuccess ? Ok(_jwtTokenGenerator.GenerateToken(request.Email)) : Unauthorized();
    }
}