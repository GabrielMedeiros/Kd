
using System;
using System.Net.Configuration;

namespace Vtex.Kd.Test
{
    public class UnifiSta
    {
        public string oui { get; set; }
        public string ap_mac { get; set; }
        public int noise { get; set; }
        public int signal { get; set; }

        protected bool Equals(UnifiSta other)
        {
            return string.Equals(oui, other.oui) && string.Equals(ap_mac, other.ap_mac) && noise == other.noise && signal == other.signal;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UnifiSta) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (oui != null ? oui.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ap_mac != null ? ap_mac.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ noise;
                hashCode = (hashCode*397) ^ signal;
                return hashCode;
            }
        }
    }
}
