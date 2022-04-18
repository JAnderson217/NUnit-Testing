using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    public class LoanRepaymentTest
    {
        [Test]
        //Pass array of values with TestCase - Pass,Pass,Pass,Fail
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        [TestCase(500_000, 10, 5, 4387.86)]
        public void CorrectMonthlyRepayment(decimal principal, decimal interestRate, int term,
            decimal expectedMonthlyPayment)
        {
            //checks correct repayment is returned - data driven, not hard coded values
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), 
                interestRate, new
                LoanTerm(term));
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }
        [Test]
        //same test as above, but assert not needed can use ExpectedResultx
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CorrectMonthlyRepayment_Simplified(decimal principal, decimal interestRate, int term)
        {
            var sut = new LoanRepaymentCalculator();
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                interestRate, new
                LoanTerm(term));
        }
        [Test]
        //same test but uses public test data from  Test Data class using TestCaseSource
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public void CorrectMonthlyRepaymentShared(decimal principal, decimal interestRate, int term,
           decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                interestRate, new
                LoanTerm(term));
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }
        [Test]
        //public test data but with .Returns
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturns), "TestCases")]
        public decimal CorrectMonthlyRepaymentSharedReturns(decimal principal, decimal interestRate, int term)
        {
            var sut = new LoanRepaymentCalculator();
            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal),
                interestRate, new
                LoanTerm(term));
        }
    }
}
