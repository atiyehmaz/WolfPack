using System;

namespace WolfPack.Contract.Wolves
{
    public class PersonalInformationDto
    {
        public string Name { get; set; }
        public GenderTypeDto GenderType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}