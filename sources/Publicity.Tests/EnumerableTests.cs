using NUnit.Framework;
using Publicity.Tests.Cases;
using Publicity.Tests.Constraints;

namespace Publicity.Tests
{
    public class EnumerableTests
    {
        [Test]
        public void RootEnumerableShouldOpenAllItems()
        {
            object sample = EnumerableFixture.Root();
            dynamic instance = sample.Open();

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());
        }

        [Test]
        public void NestedEnumerableShouldOpenAllItems()
        {
            object sample = EnumerableFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.items, Enumerates.To(2));
            Assert.That(instance.items, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance.items, Is.InstanceOf<OpenTarget>());
        }

        [Test]
        public void QueryEnumerableShouldOpenAllItems()
        {
            object sample = EnumerableFixture.Query();
            dynamic instance = sample.Open();

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());
        }
    }
}