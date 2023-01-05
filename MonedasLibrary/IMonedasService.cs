using System.Globalization;

namespace MonedasLibrary
{
    public interface IMonedasService
    {
        IEnumerable<RegionInfo> GetCurrencies();
        RegionInfo GetCurrency(string code);
    }
}