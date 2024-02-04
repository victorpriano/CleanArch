using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Queries;

public record GetMembersQuery() : IRequest<IEnumerable<Member>>;
public record GetMemberById(int id) : IRequest<Member>;

public class GetMembersHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMembersHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        => await _unitOfWork.MemberRepository.GetAll();
}

public class GetMemberByIdHandler : IRequestHandler<GetMemberById, Member>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetMemberByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Member> Handle(GetMemberById request, CancellationToken cancellationToken)
        => await _unitOfWork.MemberRepository.GetMemberById(request.id);
}