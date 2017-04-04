using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces
{
    public interface IAdminGiftAidProcessor :IGiftAidProcessor
    {
        bool UpdateTaxRateTo(decimal newTaxRate);
    }
}
