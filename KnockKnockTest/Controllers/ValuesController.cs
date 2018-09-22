using KnockKnockTest.Common;
using KnockKnockTest.Services;
using System;
using System.Web.Http;

namespace KnockKnockTest.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        private readonly ICalculationsService _calculations;

        public ValuesController(ICalculationsService calculations)
        {
            _calculations = calculations;
        }

        [HttpGet]
        [Route("Token")]
        public string Token()
        {
            return Constants.TOKEN;
        }

        [HttpGet]
        [Route("Fibonacci")]
        public IHttpActionResult Fibonacci(long n)
        {
            if (n < 0)
                return BadRequest();

            try
            {
                var result = _calculations.GetFibonacciNumber(n);
                if (result < 0)
                {
                    return BadRequest();
                }
                return Ok(result.ToString());
            }
            catch (OverflowException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ReverseWords")]
        public IHttpActionResult ReverseWords(string sentence)
        {
            var result = _calculations.ReverseWords(sentence);
            return Ok(result);
        }

        [HttpGet]
        [Route("TriangleType")]

        public IHttpActionResult TriangleType(int a, int b, int c)
        {
            var result = _calculations.TriangleType(a, b, c);
            return Ok(result);
        }
    }
}
