using NUnit.Framework;
using System;
using ColorCombination;
using NSubstitute;
using System.Collections.Generic;

namespace ColorCombinationTests
{
    [TestFixture()]
    public class ColorBandsCheckerTests
    {
		private IInputValidator _validator;
		private ICombinationFinder _combinationFinder;

		private ColorBandsChecker _checker;

		[SetUp]
        public void SetUp(){
			_validator = Substitute.For<IInputValidator>();
            _combinationFinder = Substitute.For<ICombinationFinder>();
            _checker = new ColorBandsChecker(_validator, _combinationFinder);
        }

        [Test()]
        public void CheckBands_See_If_UserInputsAreValid_Valid()
        {
            var colorSetFromUser = new UserInputColorSet() { ColorSets = new string[] { "Red,Green" } };
            _checker.CheckColorBands(colorSetFromUser);

            _validator.Received().Validate(colorSetFromUser);
        }


        [Test()]
        public void CheckBands_Throws_Exception_If_Not_Valid()
		{
			var colorSetFromUser = new UserInputColorSet();
            var exceptionMessage = "Big Exception";

            _validator.When(v => v.Validate(colorSetFromUser)).Do(v => { throw new Exception(exceptionMessage); });

			var ex = Assert.Throws<Exception>(() => _checker.CheckColorBands(colorSetFromUser));
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
		}

		[Test()]
		public void CheckBands_Calls_Combination_Finder_To_Get_New_Combination()
		{
            var colorSetFromUser = new UserInputColorSet { ColorSets = new [] { "Red,Green","Blue,Green" } };
            _combinationFinder.FindCombinationInList(Arg.Any<List<string>>(), Arg.Any<string>(), Arg.Any<string>()).Returns("Error");

            _validator.Validate(colorSetFromUser).Returns(true);
            _checker.CheckColorBands(colorSetFromUser);

            _combinationFinder.Received().FindCombinationInList(Arg.Any<List<string>>(), Arg.Any<string>(), Arg.Any<string>());
		}
    }
}
