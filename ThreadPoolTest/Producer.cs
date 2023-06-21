namespace ThreadPoolTest;

internal static class Producer
{
	public static void Produce()
	{
		while (true)
		{
			//Task.Factory.StartNew(Process, TaskCreationOptions.PreferFairness); // Using PreferFairness
			Process();

			Thread.Sleep(200);
		}
	}

	static async Task Process()
	{
		await Task.Yield();	//

		var tcs = new TaskCompletionSource<bool>();

		Task.Run(() =>
		{
			Thread.Sleep(1000);
			tcs.SetResult(true);
		});

		tcs.Task.Wait();

		ThreadPool.GetMaxThreads(out var workerThreadsMax, out var completionPortThreadsMax);
		ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);
		(int, int) idleThreads = (workerThreadsMax - workerThreads, completionPortThreadsMax - completionPortThreads);
		var total = System.Diagnostics.Process.GetCurrentProcess().Threads.Count;

		Console.WriteLine($"Ended - {DateTime.Now.ToLongTimeString()}. Threads: {total} ({idleThreads.Item1}; {idleThreads.Item2})");
	}
}
