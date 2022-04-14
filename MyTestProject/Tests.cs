using System;
using NUnit.Framework;

namespace MyTestProject
{
    [TestFixture]
    internal class Tests
    {
        [Test]
        public void stringTest()
        {
            String name = "Jack";
            //check if string is null
            //fail
            //Assert.That(name, Is.Null);
            //pass
            Assert.That(name, Is.Not.Null);
            //or check if is string is empty
            //pass
            Assert.That(name, Is.Not.Empty);
            //fail
            //Assert.That(name, Is.Empty);
            //can also check if string is equal to
            //case sensitive
            //pass, fail, pass
            //Assert.That(name, Is.EqualTo("Jack"));
            //Assert.That(name, Is.EqualTo("JACK"));
            Assert.That(name, Is.EqualTo("JACK").IgnoreCase);
            //check if string starts or ends with substring or contains
            Assert.That(name, Does.StartWith("Ja"));
            Assert.That(name, Does.Not.EndWith("P"));
            Assert.That(name, Does.Contain("ac"));
            //can combine different comparisons using and e.g. starts with and end with
            Assert.That(name, Does.StartWith("j").IgnoreCase
                                  .And.EndsWith("ack"));
            //can also use or
            Assert.That(name, Does.StartWith("32543424").IgnoreCase
                                  .Or.EndsWith("ack"));
        }
        [Test]
        public void boolTest()
        {
            Boolean value = true;
            //all pass
            Assert.That(value);
            Assert.That(value, Is.True);
            Assert.That(value, Is.Not.False);
            Assert.True(value == true);
        }

        [Test]
        public void intTest()
        {
            //int comparisons greater than, less than, in range etc.
            int x = 24;
            //all pass
            Assert.That(x, Is.GreaterThan(11));
            Assert.That(x, Is.LessThan(77));
            Assert.That(x, Is.GreaterThanOrEqualTo(24));
            Assert.That(x, Is.InRange(8, 34));
        }

        [Test]
        public void dateTimeTest()
        {
            //Is date within range
            DateTime d1 = new DateTime(2000, 2, 20);
            DateTime d2 = new DateTime(2000, 2, 25);
            //both fail
            Assert.That(d1, Is.EqualTo(d2));
            Assert.That(d1, Is.EqualTo(d2).Within(4).Days);
            //pass
            Assert.That(d1, Is.EqualTo(d2).Within(5).Days);
        }
    }
}
