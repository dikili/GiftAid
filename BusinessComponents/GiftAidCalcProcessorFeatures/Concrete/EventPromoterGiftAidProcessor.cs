using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Concrete
{
    public class EventPromoterGiftAidProcessor : GiftAidProcessor,IEventsPromoterGiftAidProcessor
    {
        private string _eventType;
        public EventPromoterGiftAidProcessor(string eventType)
        {
            _eventType = eventType;
        }
        public decimal GiftAidAmount(decimal donationAmount)
        {
            decimal giftAidAmount;
            var latestRate = GetLatestTTaxRate();
            switch (_eventType)
            {
                case "R":
                    var RRatio = latestRate / (100 - latestRate);
                    giftAidAmount= (donationAmount * RRatio ) + (donationAmount * RRatio *0.05m);  //5 percent supplement added
                    break;
                case "S":
                    var SRatio = latestRate / (100 - latestRate);
                    giftAidAmount = (donationAmount * SRatio) + (donationAmount * SRatio * 0.03m); //3 percent supplement added
                    break;
                default:
                    var DRatio = latestRate / (100 - latestRate);
                    giftAidAmount = donationAmount * DRatio; //for all other nothing additional added
                    break;
            }
            return giftAidAmount;
        }
    }
}
