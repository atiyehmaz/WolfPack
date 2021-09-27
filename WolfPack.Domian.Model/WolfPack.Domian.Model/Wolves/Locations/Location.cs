using WolfPack.Domian.Model.Shared.Common;

namespace WolfPack.Domian.Model.Wolves.Locations
{
    public class Location : ValueObject
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }

        public Location(double latitude, double longitude, string description)
        {
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
        }

        public Location()
        {
                
        }
    }
}