using System;

namespace ColorCombination
{

    public class InputValidator:IInputValidator
    {

        public bool Validate(UserInputColorSet userInput)
        {
            CheckForNullOrEmptyInput(userInput);
            CheckForInvalidSet(userInput);

            return true;
        }

        private static void CheckForInvalidSet(UserInputColorSet userInput)
        {
            foreach (string input in userInput.ColorSets)
            {
                if (input.Split(',').Length != 2)
                {
                    throw new Exception("Invalid - one of the set is invalid - not in a pair");
                }
            }
        }

        private static void CheckForNullOrEmptyInput(UserInputColorSet userInput)
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
