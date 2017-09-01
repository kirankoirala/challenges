using NUnit.Framework;
using System;
using ColorCombination;

namespace ColorCombinationTests
{
    [TestFixture()]
    public class Test
    {
        private InputValidator _validator;
		UserInputColorSet _userInput = new UserInputColorSet();

		[SetUp]
        public void Init(){
			 _validator = new InputValidator();
			_userInput = new UserInputColorSet();

		}

        [Test()]
        public void Validate_Throws_InvalidInput_For_Null_Input()
        {
            var ex = Assert.Throws<Exception>(() => _validator.isValid(null));
            Assert.That(ex.Message, Is.EqualTo("Invalid - Null input"));
        }

		[Test()]
		public void Validate_Throws_InvalidInput_For_UnInitialized_Input_List()
		{
			var ex = Assert.Throws<Exception>(() => _validator.isValid(_userInput));
			Assert.That(ex.Message, Is.EqualTo("Invalid - Uninitialized Color Set"));
		}


		[Test()]
		public void Validate_Throws_InvalidInput_For_Empty_Input_List()
		{
            _userInput.ColorSets = new string[] { };

			var ex = Assert.Throws<Exception>(() => _validator.isValid(_userInput));
			Assert.That(ex.Message, Is.EqualTo("Invalid - Empty Color Set"));
		}
    }
}
