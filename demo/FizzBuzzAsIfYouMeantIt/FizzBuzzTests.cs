using NUnit.Framework;

namespace FizzBuzzAsIfYouMeantIt {
    [TestFixture]
    public class FizzBuzzTests {
        [Test]
        public void number_divisible_by_three_gives_fizz() {
            var input = 9;
            Assert.That(NewMethod(input), Is.EqualTo("Fizz"));
        }

        private static string NewMethod(int input) {
            return input % 3 == 0 ? "Fizz" : "";
        }

        //[Test]
        //public void number_divisible_by_three_gives_fizz() {
        //    var input = 9;
        //    Assert.That(Checker(input), Is.EqualTo("Fizz"));
        //}

        [Test]
        public void number_divisible_by_five_gives_buzz() {
            var input = 10;
            Assert.That(input % 5 == 0 ? "Buzz" : "", Is.EqualTo("Buzz"));
        }

    }
}
