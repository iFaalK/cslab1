using CounterWork;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CounterWorkTest
{
    [TestClass()]
    public class CounterTest
    {
        [TestMethod]
        public void IncrementTest()
        {
            var counter = new Counter(0, 10, 5, 2);
            counter.Increment();
            Assert.AreEqual(7, counter.CurrentValue);
        }
        
        [TestMethod]
        public void DecrementTest()
        {
            var counter = new Counter(0, 10, 5, 2);
            counter.Decrement();
            Assert.AreEqual(3, counter.CurrentValue);
        }

        [TestMethod]
        public void GetCurrentValueTest()
        {
            var counter = new Counter(0, 10, 7, 2);
            Assert.AreEqual(7, counter.GetCurrentValue());
        }

        [TestMethod]
        public void ToStringTest()
        {
            var counter = new Counter(0, 100, 50, 5);
            string expected = "Counter range: min_value = 0, max_value = 100, current_value = 50, step = 5";
            Assert.AreEqual(expected, counter.ToString());
        }

        [TestMethod]
        public void EqualsTest()
        {
            var counter1 = new Counter(0, 10, 5, 2);
            var counter2 = new Counter(0, 10, 5, 2);
            Assert.IsTrue(counter1.Equals(counter2));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            var counter1 = new Counter(0, 10, 5, 2);
            var counter2 = new Counter(0, 10, 5, 2);
            Assert.AreEqual(counter1.GetHashCode(), counter2.GetHashCode());
        }

        [TestMethod("Case when CurrentValue is out of range")]
        public void SetCurrentValueOutOfRangeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Counter(0, 10, 15, 2));
        }

        [TestMethod("Case when MinValue is below 0")]
        public void SetMinValueBelowZeroTest()
        {
            var counter = new Counter(-5, 10, 0, 1);
            Assert.AreEqual(-5, counter.MinValue);
        }

        [TestMethod("Case when MaxValue is below 0")]
        public void SetMaxValueBelowZeroTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Counter(0, -10, 0, 1));
        }

        [TestMethod("Case when Step is 0, expect CurrentValue wont change")]
        public void StepIsZero_NoCurrentValueChangeTest()
        {
            var counter = new Counter(0, 10, 5, 0);
            counter.Increment();
            Assert.AreEqual(5, counter.CurrentValue);
            counter.Decrement();
            Assert.AreEqual(5, counter.CurrentValue);
        }

        [TestMethod("Case when CurrentValue goes out of range after Decrement")]
        public void DecrementBeyondMinValueTest()
        {
            var counter = new Counter(0, 10, 1, 5);
            counter.Decrement();
            Assert.AreEqual(0, counter.CurrentValue);
        }

        [TestMethod("Case when CurrentValue goes out of range after Increment")]
        public void IncrementBeyondMaxValueTest()
        {
            var counter = new Counter(0, 10, 9, 5);
            counter.Increment();
            Assert.AreEqual(10, counter.CurrentValue);
        }

    }
}
