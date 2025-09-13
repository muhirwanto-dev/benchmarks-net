using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Net8.Fundamentals
{
    [SimpleJob(RuntimeMoniker.Net80, launchCount: 1, iterationCount: 10)]
    [RPlotExporter]
    [MemoryDiagnoser]
    public class ArrayVsEnumerable
    {
        // [Params] attribute allows us to run the benchmark with different inputs.
        // This will test performance with 100, 1000, and 10000 elements.
        [Params(100, 1000, 10000)]
        public int N;

        private int[] _array = [];
        private IEnumerable<int> _enumerable = [];

        [GlobalSetup]
        public void Setup()
        {
            var data = Enumerable.Range(1, N);

            _array = data.ToArray();
            _enumerable = data;
        }

        [Benchmark(Baseline = true)]
        public int IterateOverArray()
        {
            int sum = 0;
            foreach (var item in _array)
            {
                sum += item;
            }
            return sum;
        }

        [Benchmark]
        public int IterateOverIEnumerable()
        {
            int sum = 0;
            foreach (var item in _enumerable)
            {
                sum += item;
            }
            return sum;
        }
    }
}
