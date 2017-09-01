using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorCombination
{
    public class ColorBandsChecker
    {
        private IInputValidator _validator;
        public ColorBandsChecker(IInputValidator validator)
        {
            _validator = validator;
        }

        public string CheckBands(UserInputColorSet colorSets){
           
            try
            {
                _validator.Validate(colorSets);

                var colorList = ConvertToList(colorSets);

                while(colorList.Count > 0){
                    //call the CombinationValidator
                }

            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

            return null;//just to compile successfully for now
        }

        private static List<string> ConvertToList(UserInputColorSet colorSets)
        {
            return colorSets.ColorSets.Select(u => u).ToList();
        }
    }
}
