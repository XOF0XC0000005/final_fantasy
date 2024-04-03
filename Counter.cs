using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
