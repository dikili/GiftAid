using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces
{
    interface IEventsPromoterGiftAidProcessor :IGiftAidProcessor
    {
         decimal GiftAidAmount(decimal donationAmount);
    }
}
