using Entity;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceA;
using System;
using Xunit;

namespace Test
{
    public class BankAccountServiceATest
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly Mock<ILogger<BankAccountServiceA>> _mockLogger;

        public BankAccountServiceATest()
        {
            _mockLogger = new Mock<ILogger<BankAccountServiceA>>();
            _bankAccountService = new BankAccountServiceA(_mockLogger.Object);
        }

        [Theory]
        [InlineData("11111111111", true)]
        [InlineData("11111111112", true)]
        public void Register(string cpf, bool result)
        {
            //the system under test
            var sut = _bankAccountService.Register(cpf);

            Assert.Equal(result, sut);
        }

        [Theory]
        [InlineData("11111111111", 10.0, false)]
        public void Withdraw(string cpf, decimal value, bool result)
        {
            var sut = _bankAccountService.Withdraw(cpf, value);

            Assert.Equal(result, sut);
        }

        [Theory]
        [InlineData("11111111111", 0)]
        public void Withdraw2(string cpf, decimal value)
        {
            //the system under test
            var register = _bankAccountService.Register(cpf);

            Assert.True(register);

            Assert.Throws<ArgumentException>(() => _bankAccountService.Withdraw(cpf, value));
        }

        [Theory]
        [InlineData("11111111111", 1)]
        public void Withdraw3(string cpf, decimal value)
        {
            //the system under test
            var register = _bankAccountService.Register(cpf);

            Assert.True(register);

            Assert.Throws<ArgumentException>(() => _bankAccountService.Withdraw(cpf, value));
        }

        [Theory]
        [InlineData("11111111111", 1)]
        public void Withdraw4(string cpf, decimal value)
        {
            //the system under test
            var register = _bankAccountService.Register(cpf);

            Assert.True(register);

            var deposit = _bankAccountService.Deposit(cpf, value);

            Assert.True(deposit);

            var withdraw = _bankAccountService.Withdraw(cpf, value);

            Assert.True(withdraw);
        }
    }
}
