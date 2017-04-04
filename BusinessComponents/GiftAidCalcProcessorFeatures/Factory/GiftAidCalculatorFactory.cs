using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents.GiftAidCalcProcessorFeatures.Concrete;
using BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Factory
{
    public class GiftAidCalculatorFactory :IGiftAidCalculatorFactory
    {
        public IGiftAidProcessor Resolve(int userType,string eventType="none")
        {
            switch (userType)
            {
                case 1: return new DonorGiftAidProcessor();
                case 2: return new AdminGiftAidProcessor();
                case 3: return new EventPromoterGiftAidProcessor(eventType);
                default: return new DonorGiftAidProcessor();
            }
        }
    }
}
