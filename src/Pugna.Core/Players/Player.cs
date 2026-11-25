using Pugna.Core.Matches;

namespace Pugna.Core.Players;

public class Player
{
    public required Guid AccountId { get; init; }
    public List<string> Achievements { get; } = new();
    public List<Match> Matches { get; } = new();
}
