using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview
{
    public class Salutation
    {
        private string _Greeting;
        private string _Farewell;

        public Salutation(string greetingMessage, string farewellMessage)
        {
            _Greeting = greetingMessage;
            _Farewell = farewellMessage;
        }

        public string Greet()
        {
            return _Greeting;
        }

        public string SayFarewell()
        {
            return _Farewell;
        }
    }
}
