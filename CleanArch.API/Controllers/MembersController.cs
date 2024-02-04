using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public MembersController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var members = await _unitOfWork.MemberRepository.GetAll();

        return Ok(members);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMember(int id)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberById(id);
        return member != null ? Ok(member) : NotFound("Member not found.");
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMember([FromBody] CreateMemberCommand command)
    {
        var createMember = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetMember), new { id = createMember.Id }, createMember);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
    {
        command.Id = id;
        var updatedMember = await _mediator.Send(command);

        return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found.");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        var command = new DeleteMemberCommand { Id = id };
        var deletedMember = await _mediator.Send(command);

        return deletedMember != null ? Ok(deletedMember) : NotFound("Member not found.");
    }
    
}