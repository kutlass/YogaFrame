
namespace UnitTests
{
    //
    // Account.cs is the class that we'll be running
    // our NUnit test against.
    //
    public class Account
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }

        public void TransferFunds(Account destination, decimal amount)
        {

        }

        public decimal Balance
        {
            get { return balance; }
        }
    }
}
