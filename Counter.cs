using System;

namespace final_fantasy
{
    internal class Counter : IDisposable
    {
        public void Add(ref int cnt)
        {
            cnt++;
        }

        public void Dispose() => Console.WriteLine("Счетчик очистился!");
    }
}
