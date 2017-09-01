using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorCombination
{
    public class CombinationFinder : ICombinationFinder
    {
        public string FindCombinationInList(List<string> inputList, string startColorToFind, string lastColor)
        {
            if (inputList.Count == 0) { return "Error"; }
            if (inputList.Count() == 1){
                if (inputList.First().Split(',')[1].ToLower().Trim() != lastColor.ToLower().Trim()){
                    return "Error";
                }
                else{
                    return inputList.First();
                }
            }

            var chips = inputList.Where(c => c.Split(',')[0].ToLower().Trim() == startColorToFind.ToLower().Trim());
            if (chips.Count() != 1){
                if (chips.Count() == 0) { return "Error"; }
                if (chips.Count()>chips.Distinct().Count()){
                    return "Error";
                }

                var validChips = chips.Where(c => c.Split(',')[1].ToLower().Trim() != lastColor.ToLower().Trim());
                return validChips.FirstOrDefault();
            }
            return chips.SingleOrDefault();
        }
    }
}
