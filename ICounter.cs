using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CounterWork
{
    public interface ICounter
    {
        int MinValue { get; set; }
        int MaxValue { get; set; }
        int CurrentValue { get; set; }
        int Step { get; set; }

        int GetCurrentValue();
        void Increment();
        void Decrement();
    }
}
