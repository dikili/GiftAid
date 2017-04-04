using BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces;
using DataComponents.Repositories;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Concrete
{
    public class AdminGiftAidProcessor :GiftAidProcessor,IAdminGiftAidProcessor
    {
        public override decimal GiftAidAmount(decimal donationAmount)
        {
            var latestTaxRate = GetLatestTTaxRate();
            var gaRatio = latestTaxRate / (100 - latestTaxRate);
            return donationAmount * gaRatio;
        }

        public bool UpdateTaxRateTo(decimal newTaxRate)
        {
           TaxRateRepository repo=new TaxRateRepository();
            return repo.SaveTaxRate(newTaxRate);
        }
    }
}
