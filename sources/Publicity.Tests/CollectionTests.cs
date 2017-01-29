using NUnit.Framework;
using Publicity.Tests.Cases;

namespace Publicity.Tests
{
    public class CollectionTests
    {
        [Test]
        public void RootCollectionShouldOpenAllItems()
        {
            object sample = CollectionFixture.Root();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
        }

        [Test]
        public void NestedCollectionShouldOpenAllItems()
        {
            object sample = CollectionFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.items.Count, Is.EqualTo(2));
            Assert.That(instance.items.Length, Is.EqualTo(2));

            Assert.That(instance.items, Enumerates.To(2));
            Assert.That(instance.items, Has.All.InstanceOf<OpenTarget>());
        }
    }
}