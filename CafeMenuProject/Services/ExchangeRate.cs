using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class ExchangeRateService
{
    private const string ApiUrl = "https://api.exchangerate-api.com/v4/latest/TRY"; // TCMB API URL

    public async Task<ExchangeRates> GetExchangeRatesAsync()
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetStringAsync(ApiUrl); // API'den JSON verisini al
                var data = JObject.Parse(response);

                // Döviz kuru bilgilerini parse et
                var rates = data["rates"];

                return new ExchangeRates
                {
                    UsdRate = (double)rates["USD"],
                    EuroRate = (double)rates["EUR"]
                };
            }
            catch (Exception ex)
            {
                // Hata durumunda döviz kuru verilerini varsayılan değerlerle dönebilirsiniz
                throw new Exception("Döviz kuru verilerini alırken bir hata oluştu: " + ex.Message);
            }
        }
    }
}

public class ExchangeRates
{
    public double UsdRate { get; set; }
    public double EuroRate { get; set; }
}
