using System;
using WolfPack.Domian.Model.Shared.Common;

namespace WolfPack.Domian.Model.Wolves.PersonalInformations
{
    public class PersonalInformation : ValueObject
    {
        public string Name { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime BirthDate { get; set; }

        public PersonalInformation(string name, GenderType genderType, DateTime birthDate)
        {
            Name = name;
            GenderType = genderType;
            BirthDate = TimeZoneInfo.ConvertTimeToUtc(birthDate.Truncate(TimeSpan.TicksPerSecond));
        }

        public PersonalInformation()
        {
                
        }
        
    }
}