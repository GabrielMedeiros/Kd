using NUnit.Framework;

namespace Vtex.Kd.Test
{
    [TestFixture]
    public class UnifiTest
    {
        [Test]
        public void Deve_achar_o_nome_passado_no_json()
        {
            var result = UnifiStaResponseBuilder.CreateUnifiStaResponse(JsonResult);

            var expectedOui = "SamsungE";

            var fulano = result.GetByOui(expectedOui);

            Assert.AreEqual(expectedOui,fulano.oui);

        }


        private const string JsonResult =
            "{\"data\":[{\"_id\":\"51c9cc65d0a49dbd2c04faf0\",\"_rx_bytes\":164340,\"_rx_crypts\":0,\"_rx_dropped\":0,\"_rx_errors\":0,\"_rx_frags\":0,\"_rx_packets\":1248,\"_tx_bytes\":474510,\"_tx_dropped\":0,\"_tx_errors\":0,\"_tx_packets\":1011,\"_tx_retries\":0,\"_uptime\":1225,\"ap_mac\":\"00:27:22:f6:cf:72\",\"assoc_time\":1372273657,\"auth_time\":-267014130,\"authorized\":true,\"bssid\":\"06:27:22:f7:cf:72\",\"bytes\":638850,\"bytes.d\":168,\"bytes.r\":16,\"ccq\":950,\"channel\":11,\"dhcpend_time\":0,\"dhcpstart_time\":1072,\"essid\":\"Vtex - Office\",\"first_seen\":1372179556,\"hostname\":null,\"idletime\":2,\"is_11a\":null,\"is_11b\":null,\"is_11n\":true,\"is_guest\":false,\"last_seen\":1372274882,\"mac\":\"00:07:ab:af:7a:e8\",\"map_id\":\"51c35aef98079dbd2b583804\",\"noise\":-95,\"oui\":\"SamsungE\",\"powersave_enabled\":true,\"qos_policy_applied\":true,\"radio\":\"ng\",\"rssi\":26,\"rx_bytes\":164340,\"rx_bytes.d\":168,\"rx_bytes.r\":16,\"rx_crypts\":0,\"rx_crypts.d\":0,\"rx_crypts.r\":0,\"rx_dropped\":0,\"rx_dropped.d\":0,\"rx_dropped.r\":0,\"rx_errors\":0,\"rx_errors.d\":0,\"rx_errors.r\":0,\"rx_frags\":0,\"rx_frags.d\":0,\"rx_frags.r\":0,\"rx_packets\":1248,\"rx_packets.d\":12,\"rx_packets.r\":1,\"rx_rate\":39000,\"signal\":-69,\"state\":47,\"state_ht\":true,\"state_pwrmgt\":false,\"t\":\"sta\",\"tx_bytes\":474510,\"tx_bytes.d\":0,\"tx_bytes.r\":0,\"tx_dropped\":0,\"tx_dropped.d\":0,\"tx_dropped.r\":0,\"tx_errors\":0,\"tx_errors.d\":0,\"tx_errors.r\":0,\"tx_packets\":1011,\"tx_packets.d\":0,\"tx_packets.r\":0,\"tx_power\":40,\"tx_rate\":39000,\"tx_retries\":0,\"tx_retries.d\":0,\"tx_retries.r\":0,\"uptime\":1225,\"user_id\":\"51c9cc65d0a49dbd2c04faf0\"}],\"meta\":{\"rc\":\"ok\"}}";
    }
}