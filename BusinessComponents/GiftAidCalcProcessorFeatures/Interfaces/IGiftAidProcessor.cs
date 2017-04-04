using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces
{
    public interface IGiftAidProcessor
    {
        decimal CurrentTaxRate { get; set; }
        decimal GiftAidAmount(decimal donationAmount);

        decimal GetLatestTTaxRate();
    }
}
