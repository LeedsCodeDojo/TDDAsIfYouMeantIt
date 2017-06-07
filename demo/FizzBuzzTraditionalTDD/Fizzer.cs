using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTraditionalTDD {
    public class Fizzer {

        public string Process(int number) {
            if (number % 3 == 0)
                return "Fizz";

            return "Buzz";
        }
    }
}
