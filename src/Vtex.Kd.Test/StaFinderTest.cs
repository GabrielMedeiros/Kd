using NUnit.Framework;

namespace Vtex.Kd.Test
{
    [TestFixture]
    public class StaFinderTest
    {
        [Test]
        public void Sta_at_Mezzanine_return_Mezzanine()
        {
            var sta = new UnifiSta()
            {
                oui = "test",
                noise = -95,
                signal = -25,
                ap_mac = "1:1:1"
            };

            var staFinder = new StaFinder();

            var placeInfo = staFinder.Find(sta);

            Assert.AreEqual(PlaceEnum.Mezzanine, placeInfo.Place);
        }

        [Test]
        public void Sta_at_2_floor_return_2_floor()
        {

            var sta = new UnifiSta()
            {
                oui = "test",
                noise = -95,
                signal = -65,
                ap_mac = "1:1:1"
            };

            var staFinder = new StaFinder();

            var placeInfo = staFinder.Find(sta);

            Assert.AreEqual(PlaceEnum.SecondFloor, placeInfo.Place);

        }
        
        [Test]
        public void Sta_at_10_floor_return_10_floor()
        {
            var sta = new UnifiSta()
            {
                oui = "test",
                noise = -95,
                signal = -25,
                ap_mac = "2:2:2"
            };

            var staFinder = new StaFinder();

            var placeInfo = staFinder.Find(sta);

            Assert.AreEqual(PlaceEnum.TenthFloor, placeInfo.Place);
        }

    }

    public class StaFinder
    {
        public PlaceInfo Find(UnifiSta sta)
        {
            var placeInfo = new PlaceInfo();

            if (sta.signal == -25)
                if (sta.ap_mac == "2:2:2")
                    placeInfo.Place = PlaceEnum.TenthFloor;
                else
                    placeInfo.Place = PlaceEnum.Mezzanine;
            else
                placeInfo.Place = PlaceEnum.SecondFloor;

            return placeInfo;
        }
    }

    public class PlaceInfo
    {
        public PlaceEnum Place { get; set; }
    }

    public enum PlaceEnum
    {
        Mezzanine,
        SecondFloor,
        TenthFloor
    }
}