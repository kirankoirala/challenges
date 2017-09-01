using System;
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
           
            _validator.isValid(colorSets);
            return null;//just to compile successfully for now
        }
    }
}
