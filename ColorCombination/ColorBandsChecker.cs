using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorCombination
{
    public class ColorBandsChecker
    {
		private IInputValidator _validator;
        private ICombinationFinder _combinationFinder;
        public ColorBandsChecker(IInputValidator validator, ICombinationFinder finder)
        {
            _validator = validator;
            _combinationFinder = finder;
        }

        public string CheckColorBands(UserInputColorSet colorSets){

            try
            {
                _validator.Validate(colorSets);
                var colorList = ConvertToList(colorSets);

                var startColor = GetStartColor(colorList.First());
                var endColor = GetEndColor(colorList.First());

                colorList.RemoveAt(0);
                var result = new List<string>();

                var possibleCombinationExists = true;
                while (possibleCombinationExists)
                {
                    if (colorList.Count()==0){
                        var stringOutput = string.Join("\n", result.ToArray());
                        return stringOutput;
                    }

                    var newCombination = _combinationFinder.FindCombinationInList(colorList, startColor, endColor);
                    if (newCombination != "Error"){
                        result.Add(newCombination);
                        colorList.Remove(newCombination);
                        startColor = GetEndColor(newCombination);
                    }
                    else{
                        return "Cannot unlock master panel";
                    }

                }

            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

           return "Cannot unlock master panel";
        }

        private static string GetStartColor(string block)
        {
            return block.Split(',')[0].ToUpper().Trim();
        }

		private static string GetEndColor(string block)
		{
			return block.Split(',')[1].ToUpper().Trim();
		}


		private static List<string> ConvertToList(UserInputColorSet colorSets)
        {
            return colorSets.ColorSets.Select(u => u).ToList();
        }
    }
}
