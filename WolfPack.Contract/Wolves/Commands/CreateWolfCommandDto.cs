using System;

namespace WolfPack.Contract.Wolves.Commands
{
    public class CreateWolfCommandDto
    {
        public string Code { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public LocationDto Location { get; set; }
    }
}