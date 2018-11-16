using System;
using System.Threading.Tasks;

namespace ExampleLock
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(@"----------------------------------------------------------------------");
			Console.WriteLine(@"---                       Example of lock                          ---");
			Console.WriteLine(@"----------------------------------------------------------------------");

			MethodLock();

			Console.WriteLine(@"----------------------------------------------------------------------");
			Console.WriteLine(@"Press Enter to close.");
			Console.ReadLine();
		}

		private static void MethodLock()
		{
			var account = new ClassAccount(100);
			var tasks = new Task[10];
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i] = Task.Run(() => RandomlyUpdate(account));
			}
			Task.WaitAll(tasks);
		}

		static void RandomlyUpdate(ClassAccount account)
		{
			var rnd = new Random();
			for (int i = 0; i < 10; i++)
			{
				var amount = rnd.Next(1, 10);
				bool doCredit = rnd.NextDouble() < 0.5;
				if (doCredit)
				{
					account.Credit(amount);
				}
				else
				{
					account.Debit(amount);
				}
			}
		}
	}
}
