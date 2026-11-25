using Pugna.Core.Players;

namespace Pugna.Core.Auth;

public class AuthService
{
    public Account Register(string accountName, string displayName, string email, string password)
    {
        var account = new Account
        {
            Id = Guid.Empty,
            AccountName = accountName,
            DisplayName = displayName,
            Email = email,
            PasswordHash = string.Empty
        };

        return account;
    }

    public Account? VerifyCredentials(string email, string password)
    {
        return null;
    }

    public Account? GetAccount(Guid accountId)
    {
        return null;
    }

    public bool DeleteAccount(Guid accountId)
    {
        return false;
    }
}
