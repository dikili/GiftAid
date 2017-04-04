using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComponents.Repositories
{
    public interface ITaxRateRepository
    {
        decimal GetLatestTaxRate();

        bool SaveTaxRate(decimal rate);
    }
}
