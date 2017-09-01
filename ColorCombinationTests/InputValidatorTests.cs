using NUnit.Framework;
using System;
using ColorCombination;

namespace ColorCombinationTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void Validate_Throws_InvalidInput_For_Null_Input()
        {
  			var validator = new InputValidator();
            var ex = Assert.Throws<Exception>(() => validator.isValid(null));
            Assert.That(ex.Message, Is.EqualTo("Null input"));
        }
    }
}
