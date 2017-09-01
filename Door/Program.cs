using System;
using ColorCombination;
using SimpleInjector;

namespace Door
{
    class Program
    {
		static readonly Container container;

        static Program()
		{
            container = new Container();
            ConfigureInjector();
		}

        public static void Main(string[] args)
        {
            var bandChecker = new ColorBandsChecker(new InputValidator(), new CombinationFinder());

            var userInput1 = new UserInputColorSet
            {
                ColorSets = new string[] { "Blue,Green", "Blue,Yellow", "Red,Green", "Yellow,Red", "Orange,Purple" }
            };

            var userInput2 = new UserInputColorSet
            {
                ColorSets = new string[] { "Blue,Green", "Blue,Yellow", "Red,Orange", "Red,Green", "Yellow,Red", "Orange,Red" }
			};

            var userInput3 = new UserInputColorSet
            {
				ColorSets = new string[] {
                    "Blue,Green","Blue,Green","Blue,Yellow","Green,Yellow","Orange,Red",
                    "Red,Green","Red,Orange","Yellow,Blue", "Yellow,Red"
                }
            };

            Console.WriteLine(bandChecker.CheckColorBands(userInput3));

        }

        private static void ConfigureInjector(){
			container.Register<ICombinationFinder, CombinationFinder>();
			container.Register<IInputValidator, InputValidator>();
			container.Verify();
        }
    }
}
