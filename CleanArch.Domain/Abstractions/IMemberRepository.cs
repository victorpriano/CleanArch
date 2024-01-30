using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAll();
    Task<Member> GetMemberById(int id);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int id);
}