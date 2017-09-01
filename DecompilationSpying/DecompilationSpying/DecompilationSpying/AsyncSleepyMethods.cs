using System;
using System.Threading.Tasks;

namespace DecompilationSpying
{
    public class AsyncSleepyMethods
    {
        public AsyncSleepyMethods()
        {
        }

        public void Sleepy()
        {
            Task.Delay(1000).Wait();

            //Console.WriteLine("base Sleepy");
        }

        public void SleepyComplicated(Action slee)
        {
            slee.Invoke();
        }

        public async Task<string> Sleepy5()
        {
            await Task.Run(() => Sleepy());
            return "ready Sleepy5" + Environment.NewLine;
        }

        public async Task SleepyComplicated(Func<Task> slee)
        {
            await slee();
        }

        public async Task<string> CallSleepyComplicated()
        {
            var result = string.Empty;
            result += await Sleepy5();
            result += "in Call sleepy complicated " + Environment.NewLine;
            result += await Sleepy5();
            return result;
        }

        public async Task<string> CallSleepyComplicatedAwaitingWithFunc(Func<Task<string>> call)
        {
            return await call();
        }

        public async Task<string> CallSleepyComplicatedAwaiting()
        {
            //return await CallSleepyComplicatedAwaitingWithFunc(async () => await CallSleepyComplicated());
            return await CallSleepyComplicatedAwaitingWithFunc(() => CallSleepyComplicated());
            //return await CallSleepyComplicatedAwaitingWithFunc(CallSleepyComplicated);
        }

    }
}

