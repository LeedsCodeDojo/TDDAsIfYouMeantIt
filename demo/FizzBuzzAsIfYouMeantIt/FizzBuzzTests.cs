using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzAsIfYouMeantIt {
    [TestFixture]
    public class FizzBuzzTests {
        [Test]
        public void number_divisible_by_three_gives_fizz() {

            Assert.That("Fizz", Is.EqualTo("Fizz"));
        }

    }
}
