using KnockKnockTest.Common;
using KnockKnockTest.Services;
using NUnit.Framework;
using System;

namespace KnockKnockTest.Tests.Services
{
    public class CalculationsServiceTest
    {
        private ICalculationsService _calculationsService;

        [SetUp]
        public void SetUp()
        {
            _calculationsService = new CalculationsService();
        }

        [Test]
        public void GetFibonacciNumber_ShouldReturn_ValidNumber_FromSeries()
        {
            int[] fibonacci = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
            var result = _calculationsService.GetFibonacciNumber(4);
            Assert.AreEqual(fibonacci[4], 3);
        }

        [Test]
        public void GetFibonacciNumber_ShouldReturn_Zero_For_ZeroIndex()
        {
            int[] fibonacci = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
            var result = _calculationsService.GetFibonacciNumber(0);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void GetFibonacciNumber_ShouldThrow_Exception_For_OverflowValue()
        {
            Assert.Throws<OverflowException>(() => _calculationsService.GetFibonacciNumber(6532656534567));
        }

        [Test]
        public void ReverseWords_ShouldReturn_ReversedString()
        {
            var result = _calculationsService.ReverseWords("I am being Unit Tested");
            Assert.AreEqual(result, "I ma gnieb tinU detseT");
        }

        [Test]
        public void TriangleType_ShouldReturn_ScaleneTriangleName_ForDimensions()
        {
            var result = _calculationsService.TriangleType(2, 3, 4);
            Assert.AreEqual(result, Constants.SCALENETRIANGLE);
        }

        [Test]
        public void TriangleType_ShouldReturn_EquilateralTriangleName_ForDimensions()
        {
            var result = _calculationsService.TriangleType(4, 4, 4);
            Assert.AreEqual(result, Constants.EQUILATERALTRIANGLE);
        }

        [Test]
        public void TriangleType_ShouldReturn_IsoscelesTriangleName_ForDimensions()
        {
            var result = _calculationsService.TriangleType(4, 5, 4);
            Assert.AreEqual(result, Constants.ISOSCELESTRIANGLE);
        }

        [Test]
        public void TriangleType_ShouldReturn_ErrorMessage_For_Invalid_Dimensions()
        {
            var result = _calculationsService.TriangleType(0, 5, 4);
            Assert.AreEqual(result, Constants.ERRORMESSAGE);
        }

    }
}
