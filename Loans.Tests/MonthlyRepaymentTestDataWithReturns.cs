using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    public class MonthlyRepaymentTestDataWithReturns
    {
        //Class that has test data to be used, but also with .returns
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(200_000m, 6.5m, 30).Returns(1264.14m);
                yield return new TestCaseData(200_000m, 10m, 30).Returns(1755.14m);
                yield return new TestCaseData(500_000m, 10m, 30).Returns(4387.86m);
            }
        }
    }
}
