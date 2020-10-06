using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ThreadDestroyer
{
	class Program
	{
		public static List<int> Threads = new List<int>();

		public static int Id = 1;

		static void Main(string[] args)
		{
			var end = DateTime.Now.AddMinutes(1);

			var maxThreadCount = 32;

			while (DateTime.Now < end)
			{
				Thread.Sleep(100);
				if (Threads.Count < maxThreadCount)
				{
					var t = new Thread(new ThreadStart(() => DoSomething(Id)));
					Threads.Add(Id);
					t.Start();
					Console.WriteLine($"Starting thread { Id++ }");
				}
				else
				{
					Console.WriteLine("All threads full, waiting for a free thread slot...");
					while (Threads.Count == maxThreadCount)
					{
						Thread.Sleep(100);
					}
				}
			}
		}

		public static void DoSomething(int id)
		{
			var waitUntil = DateTime.Now.AddMinutes(1);
			while(DateTime.Now < waitUntil)
			{

			}
			Console.WriteLine($"Exiting thread {id}");
			Threads = Threads.Where(x => x != id).ToList();
		}
	}
}
