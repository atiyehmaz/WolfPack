using WolfPack.Application.Wolves.Commands;
using WolfPack.Contract.Wolves;
using WolfPack.Contract.Wolves.Commands;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Domian.Model.Wolves.Locations;
using WolfPack.Domian.Model.Wolves.PersonalInformations;

namespace WolfPack.WebApi.Wolves
{
    public static class WolfExtensions
    {
        public static CreateWolfCommand ToCreateWolfCommand(this CreateWolfCommandDto createWolfCommandDto)
        {
            return new CreateWolfCommand
            {
                Code = createWolfCommandDto.Code,
                PersonalInformation = createWolfCommandDto.PersonalInformation.ToPersonalInformation(),
                Location = createWolfCommandDto.Location.ToLocation()
            };
        }

        private static PersonalInformation ToPersonalInformation(this PersonalInformationDto personalInformationDto)
        {
            return new PersonalInformation()
            {
                Name = personalInformationDto.Name,
                GenderType = (GenderType)personalInformationDto.GenderType,
                BirthDate = personalInformationDto.BirthDate
            };
        }

        private static Location ToLocation(this LocationDto locationDto)
        {
            return new Location()
            {
                Longitude = locationDto.Longitude,
                Latitude = locationDto.Latitude,
                Description = locationDto.Description
            };
        }
      
    }
}