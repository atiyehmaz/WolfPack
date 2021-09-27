using System;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.Application.Wolves.Commands
{
    public class CreateWolfCommand
    {
        public string Code { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public Location Location { get; set; }
    }
}