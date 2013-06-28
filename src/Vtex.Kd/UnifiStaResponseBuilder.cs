using Newtonsoft.Json;

namespace Vtex.Kd.Test
{
    public class UnifiStaResponseBuilder
    {
        public static UnifiStaResponse CreateUnifiStaResponse(string json)
        {
            var unifiStaResponse = JsonConvert.DeserializeObject<UnifiStaResponse>(json);

            return unifiStaResponse;
        }
    }
}