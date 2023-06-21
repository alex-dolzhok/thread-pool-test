# thread-pool-test

How does thread pool behaves on sudden load burst in asp.net app?

This code was taken from [this article](https://medium.com/criteo-engineering/net-threadpool-starvation-and-how-queuing-makes-it-worse-512c8d570527)

[Here is another](https://medium.com/@jaiadityarathore/dotnet-core-threadpool-bef2f5a37888) good resource that explains the behavior of the thread pool in asp.net app.

Try to play with different values here:
```csharp
ThreadPool.SetMinThreads()
```