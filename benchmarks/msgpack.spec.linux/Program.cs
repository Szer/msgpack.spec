using BenchmarkDotNet.Running;

namespace msgpack.spec.linux
{
    public static class Program
    {
        private static void Main(string[] args) => BenchmarkRunner.Run<NativeComparison>();
    }
}
