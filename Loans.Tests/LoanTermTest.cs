using Loans.Domain.Applications;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    [TestFixture]
    public class LoanTermTest
    {
        [Test] 
        public void ReturnTermInMonths()
        {
            //Test conversion of years to months
            //Arrange
            var sut = new LoanTerm(1);
            //Act
            var numberOfMonths = sut.ToMonths();
            //Assert
            Assert.That(numberOfMonths, Is.EqualTo(12), "Months should be 12*number of years");
        }

        [Test]
        public void StoreYears()
        {
            //Test years are stored
            var sut = new LoanTerm(1);
            Assert.That(sut.Years, Is.EqualTo(1));
            //Assert.That(sut.Years, new EqualConstraint(1));
        }
        [Test]
        public void RespectValueEquality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);
            Assert.That(a, Is.EqualTo(b));  
        }
        [Test]
        public void RespectValueInequality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);
            Assert.That(a, Is.Not.EqualTo(b));
        }
        [Test]
        public void ReferenceEqualityExample()
        {
            //testing references for equality
            //SameAs for references, EqualTo for objects
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);
            //Pass
            Assert.That(a, Is.SameAs(b));
            //Fail
            //Assert.That(a, Is.SameAs(c));
            //Pass
            Assert.That(a, Is.EqualTo(c));

            var x = new List<string> { "a", "b", "c" };
            var y = x;
            var z = new List<string> { "a", "b", "c" };
            //Pass
            Assert.That(x, Is.SameAs(y));
            //Fail
            //Assert.That(x, Is.SameAs(z));
            //Pass
            Assert.That(x, Is.EqualTo(z));

        }
        [Test]
        public void Double()
        {
            double a = 1.0/3.0;

            //Fail
            //Assert.That(a, Is.EqualTo(0.33));
            //Gives a tolerance, if value is within X of Expected then passes or within X%
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }
        [Test]
        public void NotAllowZeroYears()
        {
            //test to check exception is correctly thrown, years should be > 0
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());
            //same but checks error message is correct
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                             .With
                             .Property("Message")
                             .EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));
            //same but type safe
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                            .With
                            .Message
                            .EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));
            //test for correct exception and ParamName: years
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                            .With
                            .Property("ParamName")
                            .EqualTo("years"));
            //same but with .Matches not using strings as above
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                            .With
                            .Matches<ArgumentOutOfRangeException>(
                                ex => ex.ParamName == "years"));
        }
    }
}
