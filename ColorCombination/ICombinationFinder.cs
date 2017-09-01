using System;
using System.Collections.Generic;

namespace ColorCombination
{
    public interface ICombinationFinder
    {
        string FindCombinationInList(List<string> inputList, string startColorToFind, string lastColor);
    }
}
