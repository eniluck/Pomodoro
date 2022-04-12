using System;
using Xunit;

namespace Pomodoro.UnitTests
{
    /// <summary>
    /// Тестовый тест.
    /// </summary>
    public class MyMathTests
    {
        [Fact]
        public void Test1()
        {
            Random randrom = new Random();

            // arrange
            var a = randrom.Next(int.MinValue, int.MaxValue);
            var b = randrom.Next(int.MinValue, int.MaxValue);

            // act
            var result = MyMath.Add(a, b);

            // assert
            Assert.Equal(a + b, result);
        }

        // a + b = b + a
        // a + 0 = a
        // (a + b) + c = a + (b + c)
        [Fact]
        public void Add_commutativa()
        {
            Random randrom = new Random();

            // arrange
            var a = randrom.Next(int.MinValue, int.MaxValue);
            var b = randrom.Next(int.MinValue, int.MaxValue);

            // act
            var left = MyMath.Add(a, b);
            var right = MyMath.Add(b, a);

            // assert
            Assert.Equal(left, right);
        }

        [Fact]
        public void Add_identity()
        {
            Random randrom = new Random();

            // arrange
            var a = randrom.Next(int.MinValue, int.MaxValue);

            // act
            var result = MyMath.Add(a, 0);
            var result2 = MyMath.Add(0, a);

            // assert
            Assert.Equal(a, result);
            Assert.Equal(a, result2);
        }

        // (a + b) + c = a + (b + c)
        [Fact]
        public void Add_associative()
        {
            Random randrom = new Random();

            // arrange
            var a = randrom.Next(int.MinValue, int.MaxValue);
            var b = randrom.Next(int.MinValue, int.MaxValue);
            var c = randrom.Next(int.MinValue, int.MaxValue);

            // act
            var left = MyMath.Add(MyMath.Add(a, b),c);
            var right = MyMath.Add(a,MyMath.Add(b, c));

            // assert
            Assert.Equal(left, right);
        }
    }

    public static class MyMath
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}