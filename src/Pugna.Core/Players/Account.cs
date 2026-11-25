namespace Pugna.Core.Players;

public class Account
{
    public required Guid Id { get; init; }
    public required string AccountName { get; init; }
    public required string DisplayName { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
}
