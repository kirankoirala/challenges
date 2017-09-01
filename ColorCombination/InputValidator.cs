using System;

namespace ColorCombination
{
    public class InputValidator
    {

        public bool isValid(UserInputColorSet userInput)
        {
            
            if (userInput == null){
                throw new Exception("Null input");
            }
          return false;
        }

    }
}
