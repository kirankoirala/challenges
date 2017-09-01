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

            _validator.Received().isValid(colorSetFromUser);
        }
    }
}
