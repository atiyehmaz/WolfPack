using WolfPack.Application.Test.Wolves.Commands;
using WolfPack.Application.Wolves;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Application.Test.Wolves
{
    public static class WolfApplicationServiceExtensions
    {
            public static Wolf CreateSomeWolf(this WolfApplicationService wolfApplicationService)
            {
                var someCreateWolfCommand = new CreateWolfCommandTestBuilder()
                    .Build();
                    
                wolfApplicationService.Create(someCreateWolfCommand);
                
                return wolfApplicationService.GetByCode(someCreateWolfCommand.Code);
            }
            
            public static Wolf CreateAnotherWolf(this WolfApplicationService wolfApplicationService)
            {
                var anotherCreateWolfCommand = new CreateWolfCommandTestBuilder()
                    .BuildWithAnother();
                    
                wolfApplicationService.Create(anotherCreateWolfCommand);
                
                return wolfApplicationService.GetByCode(anotherCreateWolfCommand.Code);
            }
        
    }
}