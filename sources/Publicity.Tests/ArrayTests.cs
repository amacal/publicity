using NUnit.Framework;
using Publicity.Tests.Cases;
using Publicity.Tests.Constraints;

namespace Publicity.Tests
{
    public class ArrayTests
    {
        [Test]
        public void RootArrayShouldOpenAllItems()
        {
            object sample = ArrayFixture.Root();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance.Rank, Is.EqualTo(1));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance[0].value, Is.EqualTo(1));
            Assert.That(instance[1].value, Is.EqualTo(2));
        }

        [Test]
        public void NestedArrayShouldOpenAllItems()
        {
            object sample = ArrayFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.items.Count, Is.EqualTo(2));
            Assert.That(instance.items.Length, Is.EqualTo(2));

            Assert.That(instance.items.Rank, Is.EqualTo(1));

            Assert.That(instance.items, Enumerates.To(2));
            Assert.That(instance.items, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance.items, Is.InstanceOf<OpenTarget>());

            Assert.That(instance.items[0].value, Is.EqualTo(1));
            Assert.That(instance.items[1].value, Is.EqualTo(2));
        }

        [Test]
        public void JaggedArrayShouldOpenAllItems()
        {
            object sample = ArrayFixture.Jagged();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance.Rank, Is.EqualTo(1));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance[0], Enumerates.To(1));
            Assert.That(instance[0], Is.InstanceOf<OpenTarget>());
            Assert.That(instance[0][0].value, Is.EqualTo(1));

            Assert.That(instance[1], Enumerates.To(1));
            Assert.That(instance[1], Is.InstanceOf<OpenTarget>());
            Assert.That(instance[1][0].value, Is.EqualTo(2));
        }

        [Test]
        public void MultiArrayShouldOpenAllItems()
        {
            object sample = ArrayFixture.Multi();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(4));
            Assert.That(instance.Length, Is.EqualTo(4));

            Assert.That(instance.Rank, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(4));
            Assert.That(instance, Has.All.InstanceOf<OpenTarget>());
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance[0, 0].value, Is.EqualTo(1));
            Assert.That(instance[0, 1].value, Is.EqualTo(3));
            Assert.That(instance[1, 0].value, Is.EqualTo(2));
            Assert.That(instance[1, 1].value, Is.EqualTo(4));
        }
    }
}