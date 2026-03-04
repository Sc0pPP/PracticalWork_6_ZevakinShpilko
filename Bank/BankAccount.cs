using System;

namespace BankAccountNS
{
    /// <summary>
    /// Демонстрационный класс банковского счета.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Сообщение об ошибке при превышении суммы дебета над балансом
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке при отрицательной сумме дебета
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        /// <summary>
        /// Создает новый банковский счет
        /// </summary>
        /// <param name="customerName">Имя владельца счета</param>
        /// <param name="balance">Начальный баланс</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Получает имя владельца счета
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Получает текущий баланс счета
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Списывает средства со счета (дебет)
        /// </summary>
        /// <param name="amount">Сумма для списания</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если сумма больше баланса или меньше нуля</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Зачисляет средства на счет (кредит)
        /// </summary>
        /// <param name="amount">Сумма для зачисления</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если сумма меньше нуля</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}