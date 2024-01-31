using Domain.Members;
using Domain.Primitives;
using Domain.Teams;

namespace Domain.Careers;

public class Career(Guid id, string manager) : Entity(id)
{
    private readonly List<Team> _teams = [];

    public string Manager { get; private set; } = manager;
    public DateTime LastUpdate { get; private set; } = DateTime.Now;
    public Guid UserId { get; private set; }
    public Member? Member { get; private set; }
    public IReadOnlyCollection<Team> Teams => _teams;
}