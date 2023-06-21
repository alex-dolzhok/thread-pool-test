using ThreadPoolTest;

ThreadPool.SetMinThreads(4, 4); // governs how many worker threads will be spawned without a delay.

// The default value for worker thread count: Environment.ProcessorCount
ThreadPool.GetMinThreads(out var workerThreads, out var completionPortThreads);
Console.WriteLine($"Cores count: {Environment.ProcessorCount}");
Console.WriteLine($"Min thread pool threads: {workerThreads}; {completionPortThreads}");

Task.Factory.StartNew(
	Producer.Produce,
	TaskCreationOptions.None);
	//TaskCreationOptions.PreferFairness); // Using PreferFairness
	//TaskCreationOptions.LongRunning); // Start in a dedicated thread

Console.ReadLine();
