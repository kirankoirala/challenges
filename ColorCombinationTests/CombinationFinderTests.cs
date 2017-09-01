using NUnit.Framework;
using System;
using ColorCombination;
using System.Collections.Generic;

namespace ColorCombinationTests
{
    [TestFixture()]
    public class CombinationFinderTests
    {
        [Test()]
        public void FindCombinationInList_Returns_Error_If_List_Is_Empty()
        {
            var finder = new CombinationFinder();
            var emptyList = new List<string>();
            var result = finder.FindCombinationInList(emptyList, "Red", "Green");

            Assert.That(result, Is.EqualTo("Error"));
        }

		[Test()]
		public void FindCombinationInList_Returns_A_Combination_Started_With_Given_Color()
		{
			var finder = new CombinationFinder();
            var userList = new List<string>{"Red,Green","Blue,Green"};
			var result = finder.FindCombinationInList(userList, "Red", "Green");

			Assert.That(result, Is.EqualTo("Red,Green"));
		}


		[Test()]
		public void FindCombinationInList_Is_Not_Case_Sensitive()
		{
			var finder = new CombinationFinder();
			var userList = new List<string> { "RED,Green", "Blue,Green" };
			var result = finder.FindCombinationInList(userList, "red", "Green");

			Assert.That(result, Is.EqualTo("RED,Green"));
		}

		[Test()]
		public void FindCombinationInList_Trims_Blank_Spaces()
		{
			var finder = new CombinationFinder();
			var userList = new List<string> { " RED ,Green", "Blue,Green" };
			var result = finder.FindCombinationInList(userList, "red ", "Green");

			Assert.That(result, Is.EqualTo(" RED ,Green"));
		}



		[Test()]
		public void FindCombinationInList_Returns_Error_Match_Is_Not_Found()
		{
			var finder = new CombinationFinder();
			var userList = new List<string> { "Blue,Red" };
			var result = finder.FindCombinationInList(userList, "Red", "Green");

			Assert.That(result, Is.EqualTo("Error"));
		}

        [Test()]
        public void FindCombinationInList_Returns_Error_If_Multiple_Exact_Matches_Found()
        {
            var finder = new CombinationFinder();
            var userList = new List<string> { "Red,Green","Red,Green", "Blue,Green" };
            var result = finder.FindCombinationInList(userList, "Red", "Green");

            Assert.That(result, Is.EqualTo("Error"));
        }

		[Test()]
		public void FindCombinationInList_Returns_One_Which_DoesNot_Match_Second_Color_To_Last_Color()
		{
			var finder = new CombinationFinder();
			var userList = new List<string> { "Red,Green", "Red,Blue", "Red,Orange", "Blue,Green" };
			var result = finder.FindCombinationInList(userList, "Red", "Green");

			Assert.That(result, Is.EqualTo("Red,Blue"));
		}

		[Test()]
		public void FindCombinationInList_Returns_Error_If_List_Has_OnlyOne_And_SecondColor_Doesnot_Match_With_EndColor()
		{
			var finder = new CombinationFinder();
			var userList = new List<string> { "Red,Green" };
            var endColor = "Blue";
			var result = finder.FindCombinationInList(userList, "Red", endColor);

			Assert.That(result, Is.EqualTo("Error"));
		}


		[Test()]
		public void FindCombinationInList_Returns_The_LastOne_If_List_Has_OnlyOne_And_SecondColor_Match_With_EndColor()
		{
			var finder = new CombinationFinder();
			var userList = new List<string> { "Red,Green" };
			var endColor = "Green";
			var result = finder.FindCombinationInList(userList, "Red", endColor);

			Assert.That(result, Is.EqualTo("Red,Green"));
		}
    }
}
