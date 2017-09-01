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
           
            try{
                _validator.Validate(colorSets);


            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }

            return null;//just to compile successfully for now
        }
    }
}
