using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Concrete
{
    public  class DonorGiftAidProcessor : GiftAidProcessor,IDonorGiftAidProcessor
    {
        private decimal _currentTaxRate= 20m;

        public decimal CurrentTaxRate
        {
            get
            {
                return _currentTaxRate;
            }

            set
            {
                _currentTaxRate = value;
            }
        }

        public override decimal GiftAidAmount(decimal donationAmount)
        {
            var gaRatio = CurrentTaxRate / (100 - CurrentTaxRate);
            return Math.Round(donationAmount * gaRatio,2);
        }
    }
}
