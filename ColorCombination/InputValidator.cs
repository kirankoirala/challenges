using System;

namespace ColorCombination
{
    public class InputValidator
    {

        public bool isValid(UserInputColorSet userInput)
        {
            ValidateInput(userInput);
            return false;
        }

        private static void ValidateInput(UserInputColorSet userInput)
        {
            if (userInput == null)
            {
                throw new Exception("Invalid - Null input");
            }

            if (userInput.ColorSets == null)
            {
                throw new Exception("Invalid - Uninitialized Color Set");
            }

            if (userInput.ColorSets.Length == 0)
            {
                throw new Exception("Invalid - Empty Color Set");
            }
        }
    }
}
