using System.Collections.Generic;
using System.Linq;

namespace Vtex.Kd.Test
{
    public class UnifiStaResponse
    {
        public IList<UnifiSta> data { get; set; }


        public UnifiSta GetByOui(string oui)
        {
            var sta = data.FirstOrDefault(x => x.oui.Equals(oui));

            return sta;
        }
    }
}