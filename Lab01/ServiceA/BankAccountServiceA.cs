using Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace ServiceA
{
    public class BankAccountServiceA : IBankAccountService
    {
        private readonly ILogger<BankAccountServiceA> _logger;
        public ConcurrentDictionary<string, decimal> Customers { get; }

        public BankAccountServiceA(ILogger<BankAccountServiceA> logger)
        {
            _logger = logger;
            Customers = new ConcurrentDictionary<string, decimal>();
        }

        public bool Withdraw(string cpf, decimal value)
        {
            _logger.LogInformation($"{cpf} withdraw {value}", cpf, value);

            // if doesnt exist, return false
            if (!Customers.ContainsKey(cpf))
                return false;

            if (value <= 0)
                throw new ArgumentException("Value should be > 0", "value");

            var balance = Customers[cpf];

            if (balance < value)
                throw new ArgumentException("Value should be < balance", "value");

            Customers[cpf] -= value;
            return true;
        }

        public bool Deposit(string cpf, decimal value)
        {
            _logger.LogInformation($"{cpf} deposit {value}", cpf, value);

            // if doesnt exist, return false
            if (!Customers.ContainsKey(cpf))
                return false;

            if (value <= 0)
                throw new ArgumentException("Value should be > 0", "value");

            Customers[cpf] += value;
            return true;
        }

        public bool Register(string cpf)
        {
            _logger.LogInformation($"{cpf} register", cpf);

            // if exist, return true
            if (Customers.ContainsKey(cpf))
                return true;

            // try to add, if doesnt work, return false, otherwise return true
            return Customers.TryAdd(cpf, 0);
        }
    }
}