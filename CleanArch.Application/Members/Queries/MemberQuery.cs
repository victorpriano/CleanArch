using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Queries;

public record GetMembersQuery() : IRequest<IEnumerable<Member>>;
public record GetMemberById(int id) : IRequest<Member>;

public class GetMembersHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
{
    private readonly IMemberDapperRepository _memberDapperRepository;

    public GetMembersHandler(IMemberDapperRepository memberDapperRepository) => _memberDapperRepository = memberDapperRepository;

    public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        => await _memberDapperRepository.GetMembers();
}

public class GetMemberByIdHandler : IRequestHandler<GetMemberById, Member>
{
    private readonly IMemberDapperRepository _memberDapperRepository;
    
    public GetMemberByIdHandler(IMemberDapperRepository memberDapperRepository) => _memberDapperRepository = memberDapperRepository;

    public async Task<Member> Handle(GetMemberById request, CancellationToken cancellationToken)
        => await _memberDapperRepository.GetMemberById(request.id);
}