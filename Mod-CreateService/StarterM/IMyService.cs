namespace StarterM
{
    public interface IMyService
    {
        Guid Id { get; }
    }

    public class MyService : IMyService, IDisposable
    {
        //=> 每次會重複跑Guid.NewGuid()，每次執行結果不同
        //=> 為readonly
        //public Guid Id => Guid.NewGuid();
        
        //僅在初始時執行一次Guid.NewGuid()
        //後續不論執行幾次都會相同
        public Guid Id { get; } = Guid.NewGuid();

        public void Dispose() => Console.WriteLine(nameof(Dispose));
    }
}
