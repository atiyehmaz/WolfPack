using WolfPack.Application.Packs;
using WolfPack.Application.Test.Packs.Commands;
using WolfPack.Application.Test.Wolves.Commands;
using WolfPack.Application.Wolves;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Application.Test.Packs
{
    public static class PackApplicationServiceExtensions
    {
            public static Pack CreateSomePack(this PackApplicationService packApplicationService)
            {
                var someCreatePackCommand = new CreatePackCommandTestBuilder()
                    .Build();
                    
                packApplicationService.Create(someCreatePackCommand);
                
                return packApplicationService.GetByName(someCreatePackCommand.Name);
            }
            
            public static Pack CreateAnotherPack(this PackApplicationService packApplicationService)
            {
                var anotherCreatePackCommand = new CreatePackCommandTestBuilder()
                    .BuildWithAnother();
                    
                packApplicationService.Create(anotherCreatePackCommand);
                
                return packApplicationService.GetByName(anotherCreatePackCommand.Name);
            }
        
    }
}