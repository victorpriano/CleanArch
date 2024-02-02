using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MembersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var members = await _unitOfWork.MemberRepository.GetAll();

        return Ok(members);
    }
    
}