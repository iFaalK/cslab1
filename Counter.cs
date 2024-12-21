using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterWork
{
    public class Counter : ICounter
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
        public int Step { get; set; }

        public Counter(int minValue, int maxValue, int currentValue, int step)
        {
            if (minValue > maxValue || maxValue < 0 || currentValue < minValue || currentValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("Invalid counter initialization values.");
            }
            MinValue = minValue;
            MaxValue = maxValue;
            CurrentValue = currentValue;
            Step = step;
        }

        public Counter()
        {
            MinValue = 0;
            MaxValue = 100;
            CurrentValue = 0;
            Step = 1;
        }

        public void Increment()
        {
            if (CurrentValue + Step <= MaxValue)
            {
                CurrentValue += Step;
            }
            else
            {
                CurrentValue = MaxValue;
            }
        }

        public void Decrement()
        {
            if (CurrentValue - Step >= MinValue)
            {
                CurrentValue -= Step;
            }
            else
            {
                CurrentValue = MinValue;
            }
        }

        public int GetCurrentValue() => CurrentValue;

        public override string ToString()
        {
            return $"Counter range: min_value = {MinValue}, max_value = {MaxValue}, current_value = {CurrentValue}, step = {Step}";
        }

        public override bool Equals(object obj)
        {
            return obj is Counter counter &&
                   MinValue == counter.MinValue &&
                   MaxValue == counter.MaxValue &&
                   CurrentValue == counter.CurrentValue &&
                   Step == counter.Step;
        }

        public override int GetHashCode()
        {
            int hashCode = -1777682628;
            hashCode = hashCode * -1521134295 + MinValue.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxValue.GetHashCode();
            hashCode = hashCode * -1521134295 + CurrentValue.GetHashCode();
            hashCode = hashCode * -1521134295 + Step.GetHashCode();
            return hashCode;
        }
    }
}