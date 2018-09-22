using KnockKnockTest.Common;
using KnockKnockTest.Controllers;
using KnockKnockTest.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Web.Http.Results;

namespace KnockKnockTest.Tests.Controllers
{
    public class ValuesControllerTest
    {
        private ICalculationsService _calculations;
        private ValuesController _valuesController;

        [SetUp]
        public void SetUp()
        {
            _calculations = Substitute.For<ICalculationsService>();
            _valuesController = new ValuesController(_calculations);
        }

        [Test]
        public void Token_ShouldReturn_Token()
        {
            var result = _valuesController.Token();
            Assert.IsNotNull(result);
            Assert.AreEqual(result, Constants.TOKEN);
        }

        [Test]
        public void Fibonacci_ShouldReturn_CorrectIndex_FromSeries()
        {
            var expectedResult = 21;
            _calculations.GetFibonacciNumber(Arg.Any<long>()).Returns(expectedResult);
            var actionResult = _valuesController.Fibonacci(8);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(Convert.ToInt64(contentResult.Content), expectedResult);
        }

        [Test]
        public void Fibonacci_ShouldReturn_BadRequest_For_DataTypeOverFlow()
        {
            _calculations.GetFibonacciNumber(Arg.Any<long>()).Returns(-1);
            var actionResult = _valuesController.Fibonacci(Arg.Any<long>());
            Assert.IsInstanceOf<BadRequestResult>(actionResult);
        }

        [Test]
        public void Fibonacci_ShouldReturn_BadRequest_For_InvalidInput()
        {
            var actionResult = _valuesController.Fibonacci(-1);
            _calculations.DidNotReceive().GetFibonacciNumber(Arg.Any<long>());
            Assert.IsInstanceOf<BadRequestResult>(actionResult);
        }

        [Test]
        public void ReverseWords_ShouldReturn_ReversedString_For_NonEmpty_String()
        {
            var expectedResult = "tinu tset sseccus";
            _calculations.ReverseWords(Arg.Any<string>()).Returns(expectedResult);
            var actionResult = _valuesController.ReverseWords("unit test success");
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content, expectedResult);
        }

        [Test]
        public void ReverseWords_ShouldReturn_EmptyString_ForEmptyInput()
        {
            var expectedResult = string.Empty;
            var actionResult = _valuesController.ReverseWords("");
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            _calculations.ReverseWords(Arg.Any<string>()).Returns(string.Empty);
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content, expectedResult);
        }

        [Test]
        public void TriangleType_ShouldReturn_TriangleName_For_NonZero_Dimensions()
        {
            var expectedResult = Constants.SCALENETRIANGLE;
            _calculations.TriangleType(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(expectedResult);
            var actionResult = _valuesController.TriangleType(2, 3, 5);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content, expectedResult);
        }

    }
}
