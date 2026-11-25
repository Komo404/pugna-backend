using Pugna.Core.Auth;
using Pugna.Core.Players;

namespace Pugna.Infra.Persistence;

public class AuthRepository : IAuthRepository
{
    public Account? GetAccountById(Guid accountId)
    {
        return null;
    }

    public Account? GetAccountByEmail(string email)
    {
        return null;
    }

    public Account CreateAccount(Account account)
    {
        return account;
    }

    public bool DeleteAccount(Guid accountId)
    {
        return false;
    }
}
