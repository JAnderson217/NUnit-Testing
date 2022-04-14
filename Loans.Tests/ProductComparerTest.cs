using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    public class ProductComparerTest
    {
        private List<LoanProduct> products;
        private ProductComparer sut;
        //OneTimeSetUp called only at start, not before each test
        //Better for larger lists, don't have to recreate multiple times
        //Assumption vars created here not modified, as will change other tests
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            products = new List<LoanProduct>
            {
                new LoanProduct(1, "a", 1),
                new LoanProduct(2, "b", 2),
                new LoanProduct(3, "c", 3),
            };
        }
        //OneTimeTearDown same principle, only runs once, after last test 
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //products.Dispose();
        }

        //SetUp Called before each test
        [SetUp]
        public void Setup()
        {
            sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
        }
        //TearDown called after each test
        [TearDown]
        public void TearDown()
        {
            //Runs after each test
            //sut.Dispose();
        }


        [Test]
        public void ReturnCorrectNumberComparisons()
        {
            //check for correct number of products
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));
            Assert.That(comparisons, Has.Exactly(3).Items);
        }
        [Test]
        public void NotReturnDuplicateComparisons()
        {
            //check each product is unique
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));
            Assert.That(comparisons, Is.Unique);
        }
        [Test]
        public void ReturnComparisonFirstProduct()
        {
            //check to see if product is in list
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));
            //need to also know expected monthly repayment
            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);
            Assert.That(comparisons, Does.Contain(expectedProduct));
        }
        [Test]
        public void ReturnComparisonFirstProductPartialKnown()
        {
            //check to see if product is in list with partial known values
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));
            //works with only partial knowledge, not knowing monthly repayment
            /*Assert.That(comparisons, Has.Exactly(1)
                                        .Property("ProductName").EqualTo("a")
                                        .And
                                        .Property("InterestRate").EqualTo(1)
                                        .And
                                        .Property("MonthlyRepayment").GreaterThan(0));*/
            //better way, type safe as ProductName, InterestRate etc all strings
            Assert.That(comparisons, Has.Exactly(1)
                                        .Matches<MonthlyRepaymentComparison>(
                                                item => item.ProductName == "a" &&
                                                        item.InterestRate == 1 &&
                                                        item.MonthlyRepayment > 0));
        }

    }
}
