using WolfPack.Application.Packs.Commands;
using WolfPack.Contract.Packs.Commands;

namespace WolfPack.WebApi.Packs
{
    public static class PackExtensions
    {
        public static CreatePackCommand ToCreatePackCommand(this CreatePackCommandDto createPackCommandDto)
        {
            return new CreatePackCommand
            {
                Name = createPackCommandDto.Name,
                Wolves = createPackCommandDto.Wolves
            };
        }

        public static AddWolfToPackCommand ToAddPersonageToGroupCommand(
            this AddWolfToPackCommandDto addWolfToPackCommandDto)
        {
            return new AddWolfToPackCommand
            {
                Id = addWolfToPackCommandDto.Id,
                Wolf = addWolfToPackCommandDto.Wolf
            };
        }

        public static EditPackCommand ToEditPackCommand(this EditPackCommandDto editPackCommandDto)
        {
            return new EditPackCommand
            {
                Id = editPackCommandDto.Id,
                Name = editPackCommandDto.Name,
                Wolves = editPackCommandDto.Wolves
            };
        }
    }
}