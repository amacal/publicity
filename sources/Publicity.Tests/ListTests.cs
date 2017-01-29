using NUnit.Framework;
using Publicity.Tests.Cases;
using Publicity.Tests.Constraints;

namespace Publicity.Tests
{
    public class ListTests
    {
        [Test]
        public void RootListShouldOpenAllItems()
        {
            object sample = ListFixture.Root();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance[0].value, Is.EqualTo(1));
            Assert.That(instance[1].value, Is.EqualTo(2));
        }

        [Test]
        public void NestedListShouldOpenAllItems()
        {
            object sample = ListFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.items.Count, Is.EqualTo(2));
            Assert.That(instance.items.Length, Is.EqualTo(2));

            Assert.That(instance.items, Enumerates.To(2));
            Assert.That(instance.items, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance.items, Is.InstanceOf<OpenTarget>());

            Assert.That(instance.items[0].value, Is.EqualTo(1));
            Assert.That(instance.items[1].value, Is.EqualTo(2));
        }

        [Test]
        public void GenericListShouldOpenAllItems()
        {
            object sample = ListFixture.Generic();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance[0].value, Is.EqualTo(1));
            Assert.That(instance[1].value, Is.EqualTo(2));
        }
    }
}