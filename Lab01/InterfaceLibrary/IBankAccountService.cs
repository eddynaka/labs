using System.Collections.Concurrent;

namespace Entity
{
    public interface IBankAccountService
    {
        ConcurrentDictionary<string, decimal> Customers { get; }

        bool Withdraw(string cpf, decimal value);

        bool Deposit(string cpf, decimal value);

        bool Register(string cpf);
    }
}
