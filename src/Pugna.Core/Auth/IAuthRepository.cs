using Pugna.Core.Players;

namespace Pugna.Core.Auth;

public interface IAuthRepository
{
    Account? GetAccountById(Guid accountId);
    Account? GetAccountByEmail(string email);
    Account CreateAccount(Account account);
    bool DeleteAccount(Guid accountId);
}
