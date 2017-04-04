using System;
using BusinessComponents.GiftAidCalcProcessorFeatures.Concrete;
using BusinessComponents.GiftAidCalcProcessorFeatures.Factory;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Please choose user type :\n");
            Console.WriteLine("1 for Donor :\n");
            Console.WriteLine("2 for Administrator :\n");
            Console.WriteLine("3 for Events Promoter :\n");
            var userType = int.Parse(Console.ReadLine());
            GiftAidCalculatorFactory fact=new GiftAidCalculatorFactory();
		    switch (userType)
		    {
                case 1:
                    Console.WriteLine("Please Enter donation amount:");
                    Console.WriteLine(fact.Resolve(userType).GiftAidAmount(decimal.Parse(Console.ReadLine())));
		            break;
                case 2:
                    Console.WriteLine("Please Enter donation amount:");
                    Console.WriteLine(fact.Resolve(userType).GiftAidAmount(decimal.Parse(Console.ReadLine())));
                    break;
                case 3:
                    Console.WriteLine("Please Enter event type ,R for running, S for swimming and any key for any other activity");
		            var eventType = Console.ReadLine().ToUpper();
                    Console.WriteLine("Please Enter donation amount:");
                    Console.WriteLine(fact.Resolve(userType,eventType).GiftAidAmount(decimal.Parse(Console.ReadLine())));
                    break;
      
		    }
            // Calc Gift Aid Based on Previous

           // fact.Resolve(userType).GetCurrentTTaxRate()
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}

	}
}
