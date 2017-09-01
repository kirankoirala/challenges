using NUnit.Framework;
using System;
using ColorCombination;
using NSubstitute;

namespace ColorCombinationTests
{
    [TestFixture()]
    public class ColorBandsCheckerTests
    {
		private IInputValidator _validator;
        private ColorBandsChecker _checker;

		[SetUp]
        public void SetUp(){
            _validator = Substitute.For<IInputValidator>();
            _checker = new ColorBandsChecker(_validator);
        }

        [Test()]
        public void CheckBands_See_If_UserInputsAreValid_Valid()
        {
            var colorSetFromUser = new UserInputColorSet();
            _checker.CheckBands(colorSetFromUser);

            _validator.Received().Validate(colorSetFromUser);
        }


        [Test()]
        public void CheckBands_Throws_Exception_If_Not_Valid()
		{
			var colorSetFromUser = new UserInputColorSet();
            var exceptionMessage = "Big Exception";

            _validator.When(v => v.Validate(colorSetFromUser)).Do(v => { throw new Exception(exceptionMessage); });

			var ex = Assert.Throws<Exception>(() => _checker.CheckBands(colorSetFromUser));
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
		}
    }
}
