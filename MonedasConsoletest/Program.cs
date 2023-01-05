

using MonedasLibrary;

MonedasService monedasService = new MonedasService();

//foreach (var item in monedasService.GetCurrencies().ToList())
//{
    Console.WriteLine(monedasService.GetCurrency("CRC").NativeName +"  "+ "   "+ monedasService.GetCurrency("CRC").EnglishName);
//}
Console.ReadKey();

