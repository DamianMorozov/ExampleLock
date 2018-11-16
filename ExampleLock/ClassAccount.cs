using System;

namespace ExampleLock
{
	internal class ClassAccount
	{
		private readonly object balanceLock = new object();
		private decimal balance;

		public ClassAccount(decimal initialBalance)
		{
			balance = initialBalance;
		}

		public decimal Debit(decimal amount)
		{
			lock (balanceLock)
			{
				if (balance >= amount)
				{
					Console.WriteLine($"Balance before debit : {balance,5}");
					Console.WriteLine($"Amount to remove     :-{amount,5}");
					balance = balance - amount;
					Console.WriteLine($"Balance after debit  : {balance,5}");
					return amount;
				}
				else
				{
					return 0;
				}
			}
		}

		public void Credit(decimal amount)
		{
			lock (balanceLock)
			{
				Console.WriteLine($"Balance before credit: {balance,5}");
				Console.WriteLine($"Amount to add        :+{amount,5}");
				balance = balance + amount;
				Console.WriteLine($"Balance after credit : {balance,5}");
			}
		}
	}
}
