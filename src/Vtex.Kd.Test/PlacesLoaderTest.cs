using System;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Vtex.Kd.Test
{
    [TestFixture]
    public class PlacesLoaderTest
    {
        [Test]
        public void LoadPlacesFile()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var placesLoader = new PlacesLoader(path + "\\Places.json");

            var places = placesLoader.GetPlaces();

            var expectedPlace = CreateExpectedPlace();

            Assert.AreEqual(2, places.Count);
            Assert.AreEqual(expectedPlace,places[0]);
        }
        
        private static MapPlace CreateExpectedPlace()
        {
            var expectedPlace = new MapPlace
            {
                Name = "SobreLoja",
                Coordinates = new List<MapCoordinate>
                {
                    new MapCoordinate
                    {
                        Ap_mac = "1:1:1",
                        PossiblePoints = new List<WifiSignalPoint>
                        {
                            new WifiSignalPoint
                            {
                                Noise = -90,
                                Signal = -50,
                            }
                        }
                    },
                    new MapCoordinate
                    {
                        Ap_mac = "2:2:2",
                        PossiblePoints = new List<WifiSignalPoint>
                        {
                            new WifiSignalPoint
                            {
                                Noise = -90,
                                Signal = -70
                            },
                            new WifiSignalPoint
                            {
                                Noise = -90,
                                Signal = -65
                            }
                        }
                    }
                }
            };
            return expectedPlace;
        }
    }

    public class PlacesLoader
    {
        private readonly IList<MapPlace> mapPlaces;

        public PlacesLoader(string placesFilePath)
        {
            mapPlaces = new List<MapPlace>();

            var file = new FileInfo(placesFilePath);

            var placesJson = file.OpenText().ReadToEnd();

            mapPlaces = JsonConvert.DeserializeObject<IList<MapPlace>>(placesJson);
        }

        public IList<MapPlace> GetPlaces()
        {
            return mapPlaces;
        }
    }

    public class MapPlace
    {
        public string Name { get; set; }
        public IList<MapCoordinate> Coordinates { get; set; }

        private bool Equals(MapPlace other)
        {
            return string.Equals(Name, other.Name) 
                && Coordinates.All(x=> other.Coordinates.Any(y=>y.Equals(x)));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MapPlace)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Coordinates != null ? Coordinates.GetHashCode() : 0);
            }
        }
    }

    public class MapCoordinate
    {
        public string Ap_mac { get; set; }
        public IList<WifiSignalPoint> PossiblePoints { get; set; }

        private bool Equals(MapCoordinate other)
        {
            return string.Equals(Ap_mac, other.Ap_mac) &&
                PossiblePoints.All(x => other.PossiblePoints.Any(y => y.Equals(x)));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MapCoordinate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Ap_mac != null ? Ap_mac.GetHashCode() : 0) * 397) ^ (PossiblePoints != null ? PossiblePoints.GetHashCode() : 0);
            }
        }
    }

    public class WifiSignalPoint
    {
        public int Noise { get; set; }
        public int Signal { get; set; }

        private bool Equals(WifiSignalPoint other)
        {
            return Noise == other.Noise && Signal == other.Signal;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((WifiSignalPoint)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Noise * 397) ^ Signal;
            }
        }

    }

    public class NetWorkGeoMap
    {
    }

}