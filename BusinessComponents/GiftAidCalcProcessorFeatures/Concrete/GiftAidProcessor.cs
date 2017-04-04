using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces;
using DataComponents.Repositories;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Concrete
{
    public abstract class GiftAidProcessor :IGiftAidProcessor
    {
        public virtual decimal GiftAidAmount(decimal donationAmount)
        {
            var gaRatio = 17.5m / (100 - 17.5m);
            return donationAmount * gaRatio;
        }

      
        public decimal CurrentTaxRate { get; set; }
        public decimal GetLatestTTaxRate()
        {
            //IoC not done since not required but injection could be done for the repository here
            TaxRateRepository rep =new TaxRateRepository();
            return rep.GetLatestTaxRate();
        }
    }
}
