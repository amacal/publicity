using System.Dynamic;
using NUnit.Framework;
using Publicity.Tests.Cases;

namespace Publicity.Tests
{
    public class EntityTests
    {
        [Test]
        public void EmptyEntityShouldReturnNotNull()
        {
            object sample = EntityFixture.Empty();
            dynamic instance = sample.Open();

            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void PropertyEntityShouldReturnItsValue()
        {
            object sample = EntityFixture.Property();
            dynamic instance = sample.Open();

            Assert.That(instance.value, Is.EqualTo(1));
        }

        [Test]
        public void NestedEntityShouldReturnItsValue()
        {
            object sample = EntityFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.data.value, Is.EqualTo(1));
        }

        [Test]
        public void RegularEntityShouldNotBeWrapped()
        {
            object sample = EntityFixture.Regular();
            dynamic instance = sample.Open();

            Assert.That(instance, Is.Not.InstanceOf<DynamicObject>());
        }

        [Test]
        public void NullEntityShouldReturnNull()
        {
            object sample = EntityFixture.Null();
            dynamic instance = sample.Open();

            Assert.That(instance, Is.Null);
        }

        [Test]
        public void NulledEntityShouldReturnNull()
        {
            object sample = EntityFixture.Nulled();
            dynamic instance = sample.Open();

            Assert.That(instance.data, Is.Null);
        }
    }
}