using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataComponents.Repositories
{
    public class TaxRateRepository :ITaxRateRepository
    {
        public decimal GetLatestTaxRate()
        {
            return Convert.ToDecimal(ConfigurationManager.AppSettings["TaxRate"]);
        }

        public bool SaveTaxRate(decimal rate)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name.Equals("appSettings"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("TaxRate"))
                            {
                                node.Attributes[1].Value = rate.ToString();
                            }
                        }
                    }
                }

                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                ConfigurationManager.RefreshSection("appSettings");

               return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
