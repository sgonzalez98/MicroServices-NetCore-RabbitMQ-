using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Services;

public class AccountService: IAccountService
{
    private readonly AccountRepository _accountRepository;
    
    public AccountService(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _accountRepository.GetAccounts();
    }
    
}