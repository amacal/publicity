using NUnit.Framework;
using Publicity.Tests.Cases;
using Publicity.Tests.Constraints;

namespace Publicity.Tests
{
    public class DictionaryTests
    {
        [Test]
        public void RootDictionaryShouldOpenAllItems()
        {
            object sample = DictionaryFixture.Root();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance.Keys.Count, Is.EqualTo(2));
            Assert.That(instance.Keys, Has.None.InstanceOf<OpenTarget>());

            Assert.That(instance.Values.Count, Is.EqualTo(2));
            Assert.That(instance.Values, Has.All.InstanceOf<OpenTarget>());

            Assert.That(instance["a"].value, Is.EqualTo(1));
            Assert.That(instance[123].value, Is.EqualTo(2));
        }

        [Test]
        public void NestedDictionaryShouldOpenAllItems()
        {
            object sample = DictionaryFixture.Nested();
            dynamic instance = sample.Open();

            Assert.That(instance.items.Count, Is.EqualTo(2));
            Assert.That(instance.items.Length, Is.EqualTo(2));

            Assert.That(instance.items, Enumerates.To(2));
            Assert.That(instance.items, Is.InstanceOf<OpenTarget>());

            Assert.That(instance.items.Keys.Count, Is.EqualTo(2));
            Assert.That(instance.items.Keys, Has.None.InstanceOf<OpenTarget>());

            Assert.That(instance.items.Values.Count, Is.EqualTo(2));
            Assert.That(instance.items.Values, Has.All.InstanceOf<OpenTarget>());

            Assert.That(instance.items["a"].value, Is.EqualTo(1));
            Assert.That(instance.items[123].value, Is.EqualTo(2));
        }

        [Test]
        public void GenericDictionaryShouldOpenAllItems()
        {
            object sample = DictionaryFixture.Generic();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance.Keys.Count, Is.EqualTo(2));
            Assert.That(instance.Keys, Has.None.InstanceOf<OpenTarget>());

            Assert.That(instance.Values.Count, Is.EqualTo(2));
            Assert.That(instance.Values, Has.All.InstanceOf<OpenTarget>());

            Assert.That(instance["a"].value, Is.EqualTo(1));
            Assert.That(instance["b"].value, Is.EqualTo(2));
        }

        [Test]
        public void KeysDictionaryShouldOpenAllItems()
        {
            object sample = DictionaryFixture.Keys();
            dynamic instance = sample.Open();

            Assert.That(instance.Count, Is.EqualTo(2));
            Assert.That(instance.Length, Is.EqualTo(2));

            Assert.That(instance, Enumerates.To(2));
            Assert.That(instance, Is.InstanceOf<OpenTarget>());

            Assert.That(instance.Keys.Count, Is.EqualTo(2));
            Assert.That(instance.Keys, Has.All.InstanceOf<OpenTarget>());

            Assert.That(instance.Values.Count, Is.EqualTo(2));
            Assert.That(instance.Values, Has.All.InstanceOf<OpenTarget>());

            foreach (dynamic key in instance.Keys)
            {
                Assert.That(instance[key].value, Is.EqualTo(key.id));
            }
        }
    }
}