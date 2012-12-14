namespace PseudoLocalizer.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class TransformTests
    {
        [Test]
        public void TestExtraLength()
        {
            Assert.That(ExtraLength.Transform(string.Empty), Is.EqualTo(string.Empty), "No extra length added to the empty string.");

            var singleWord = "hello";
            var transformed = ExtraLength.Transform(singleWord);
            Assert.That(transformed.Length, Is.GreaterThan(singleWord.Length));
            Assert.That(transformed.Split(' ').Length, Is.EqualTo(singleWord.Split(' ').Length), "The number of words stays the same.");

            var sentence = "The quick brown fox bla bla bla.";
            transformed = ExtraLength.Transform(sentence);
            Assert.That(transformed.Length, Is.GreaterThan(sentence.Length));
            Assert.That(transformed.Split(' ').Length, Is.EqualTo(sentence.Split(' ').Length), "The number of words stays the same.");
        }

        [Test]
        public void TestBrackets()
        {
            Assert.That(Brackets.Transform(string.Empty), Is.EqualTo("[]"));
            Assert.That(Brackets.Transform("hello"), Is.EqualTo("[hello]"));
            Assert.That(Brackets.Transform("The quick brown fox bla bla bla."), Is.EqualTo("[The quick brown fox bla bla bla.]"));
        }

        [Test]
        public void TestMirror()
        {
            Assert.That(Mirror.Transform(string.Empty), Is.EqualTo(string.Empty));
            Assert.That(Mirror.Transform("hello, world!"), Is.EqualTo("!dlrow ,olleh"));
        }

        [Test]
        public void TestUnderscores()
        {
            Assert.That(Underscores.Transform(string.Empty), Is.EqualTo(string.Empty));
            var message = "hello, world!";
            Assert.That(Underscores.Transform(message), Is.EqualTo(new string('_', message.Length)));
        }
    }
}
