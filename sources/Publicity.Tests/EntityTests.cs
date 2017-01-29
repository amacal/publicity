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
            Assert.That(instance, Is.InstanceOf<OpenTarget>());
        }

        [Test]
        public void PropertyEntityShouldReturnItsValue()
        {
            object sample = EntityFixture.Property();
            dynamic instance = sample.Open();

            Assert.That(instance.value, Is.EqualTo(1));
            Assert.That(instance, Is.InstanceOf<OpenTarget>());
        }

        [Test]
        public void NestedEntityShouldReturnItsValue()
        {
            object sample = EntityFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.data.value, Is.EqualTo(1));
            Assert.That(instance.data, Is.InstanceOf<OpenTarget>());
        }

        [Test]
        public void RegularEntityShouldNotBeWrapped()
        {
            object sample = EntityFixture.Regular();
            dynamic instance = sample.Open();

            Assert.That(instance, Is.Not.InstanceOf<OpenTarget>());
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

        [Test]
        public void DynamicEntityShouldReturnItsValue()
        {
            object sample = EntityFixture.Dynamic();
            dynamic instance = sample.Open();

            Assert.That(instance.value, Is.EqualTo(1));
            Assert.That(instance, Is.Not.InstanceOf<OpenTarget>());
        }
    }
}