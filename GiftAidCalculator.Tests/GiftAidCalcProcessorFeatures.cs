using System;
using System.CodeDom;
using BusinessComponents.GiftAidCalcProcessorFeatures.Concrete;
using BusinessComponents.GiftAidCalcProcessorFeatures.Factory;
using Moq;
using NUnit.Framework;
using BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces;
using DataComponents.Repositories;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class GiftAidCalcProcessorFeatures
    {


        #region Story1 Tests
        // As a donor
        // I want to see my gift aid calculated according to the current tax rate (20)
        // So that I know how much extra cash the charity will make


        [TestCase]
        public void CalculateGiftAidWithForDonorCorrectly()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new DonorGiftAidProcessor());

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;

            
            // Regardless of what is passed donorgiftaidcalculater triggered...
            var donorGiftAidCalculator = giftAidFactory.Resolve(1);

            //if the donation amount is 30 and tax rate is current at 20 
            var result= donorGiftAidCalculator.GiftAidAmount(30);
            
            //result should equal to 7.5 if tax is 20(current rate)
            Assert.AreEqual(result,7.5m);
          
          
        }
        [TestCase]
        public void CheckIfCurrentTaxRateAt20()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new DonorGiftAidProcessor());

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;

            // Regardless of what is passed donorgiftaidcalculater triggered...
            var donorGiftAidCalculator = giftAidFactory.Resolve(1);

            int amountToGive = 50;
            //Regardless of the amount passed 
            var result = donorGiftAidCalculator.GiftAidAmount(amountToGive);

            var Rate = result / amountToGive;
            //current tax rate is calculated with justgiving formula
            var currentTaxRate =(100 * Rate) / (1 + Rate);
            
            Assert.AreEqual(currentTaxRate, 20);


        }

        #endregion

        #region Story2 Tests

        [TestCase]
        public void AsAnAdminIShouldbeAbleToUpdateTaxRate()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new AdminGiftAidProcessor());

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;


            var adminGiftAidProcessor=new AdminGiftAidProcessor();
            //update the rate to 40
            var isUpdated=adminGiftAidProcessor.UpdateTaxRateTo(40);

            var adminGiftAidCalculator = giftAidFactory.Resolve(100);

            var latestTaxRate = adminGiftAidCalculator.GetLatestTTaxRate();

            //should be updated
            Assert.AreEqual(isUpdated, true);
            //new value read from repository should be 40
            Assert.AreEqual(latestTaxRate,40);


        }
        #endregion

        #region Story3 Tests

        [TestCase]
        public void AsADonorResultShouldAlwaysRounded2DecimalPoints()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new DonorGiftAidProcessor());

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;

        
            var adminGiftAidCalculator = giftAidFactory.Resolve(2);
            //result is more than 2 decimal points if there is no rounding for 129.9m
            var amountAid = adminGiftAidCalculator.GiftAidAmount(126.9m);

            //new value read from repository should be 40
            Assert.AreEqual(amountAid.ToString().Split('.')[1].Length, 2);


        }
        #endregion


        #region Story4 Tests
        [TestCase]
        public void AsAnEventPromoterRunningGiftAidShouldBe5PercentExtraThanNormalAid()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new EventPromoterGiftAidProcessor("R"));

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;


            var eventPromoterGiftAidCalculator = giftAidFactory.Resolve(2);

            var amountAid = eventPromoterGiftAidCalculator.GiftAidAmount(50);

            var adminGiftAidCalculater = new AdminGiftAidProcessor();

            var resultless =
                adminGiftAidCalculater.GiftAidAmount(50);
            //new value read from repository should be 40
            Assert.AreEqual(resultless + (resultless * 0.05m), amountAid);
            //new value read from repository should be 40
        }
        [TestCase]
        public void AsAnEventPromoterSwimingGiftAidShouldBe3PercentExtraThanNormalAid()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new EventPromoterGiftAidProcessor("S"));

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;

            var eventPromoterGiftAidCalculator = giftAidFactory.Resolve(2);
          
            var amountAid = eventPromoterGiftAidCalculator.GiftAidAmount(50);

            var adminGiftAidCalculater = new AdminGiftAidProcessor();

            var resultless =
                adminGiftAidCalculater.GiftAidAmount(50);
            //new value read from repository should be 40
            Assert.AreEqual(resultless + (resultless * 0.03m), amountAid);
            //new value read from repository should be 40
        }

        [TestCase]
        public void AsAnEventPromoterAnyOtherEventThanSwimmingOrRunningShouldBeSameWithNormal()
        {

            var mockFactory = new Mock<IGiftAidCalculatorFactory>();

            mockFactory.Setup(fact => fact.Resolve(It.IsAny<int>(), It.IsAny<string>())).Returns(new EventPromoterGiftAidProcessor("O"));

            IGiftAidCalculatorFactory giftAidFactory = mockFactory.Object;

            var eventPromoterGiftAidCalculator = giftAidFactory.Resolve(2);

            var amountAid = eventPromoterGiftAidCalculator.GiftAidAmount(50);

            var adminGiftAidCalculater = new AdminGiftAidProcessor();

            var result =
                adminGiftAidCalculater.GiftAidAmount(50);
            //new value read from repository should be 40
            Assert.AreEqual(result , amountAid);
            //new value read from repository should be 40
        }
        #endregion

    }
}
