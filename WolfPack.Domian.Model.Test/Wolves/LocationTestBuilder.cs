using WolfPack.Domian.Model.Wolves.Locations;

namespace WolfPack.Domian.Model.Test.Wolves
{
    public class LocationTestBuilder
    {
        public static long SomeLatitude = 15;
        public static long SomeLongitude  = 30;
        public const string SomeDescription= "SomeDescription";

        public static long AnotherLatitude = 40;
        public static long AnotherLongitude  = 50;
        public const string AnotherDescription= "AnotherDescription";

        public  Location Build()
        {
            return new Location(SomeLatitude, SomeLongitude, SomeDescription);
        }
        
        public  Location BuildWithAnother()
        {
            return new Location(AnotherLatitude, AnotherLongitude, AnotherDescription);
        }
    }
}