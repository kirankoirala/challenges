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

		[TestCase("")]
        [TestCase("RedGreen")]
        [TestCase("Red,Green,Blue")]
        public void Validate_Throws_InvalidInput_If_Any_Of_Input_Is_Not_In_Pair(string input)
		{
			_userInput.ColorSets = new string[] {input };

			var ex = Assert.Throws<Exception>(() => _validator.isValid(_userInput));
			Assert.That(ex.Message, Is.EqualTo("Invalid - one of the set is invalid - not in a pair"));
		}


		[Test()]
        public void Validate_Returns_True_For_Valid_Input()
		{
            _userInput.ColorSets = new string[] { "Red,Blue", "Green,Red", "Orange,Yellow" };

			var validationResult = _validator.isValid(_userInput);
            Assert.True(validationResult);
		}
    }
}
