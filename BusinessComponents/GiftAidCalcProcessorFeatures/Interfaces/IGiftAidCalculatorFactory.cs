using BusinessComponents.GiftAidCalcProcessorFeatures.Concrete;

namespace BusinessComponents.GiftAidCalcProcessorFeatures.Interfaces
{
    public interface IGiftAidCalculatorFactory
    {
        IGiftAidProcessor Resolve(int userType,string eventType="none");
    }
}
