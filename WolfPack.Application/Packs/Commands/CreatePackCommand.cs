using System;
using System.Collections.Generic;

namespace WolfPack.Application.Packs.Commands
{
    public class CreatePackCommand
    {
        public string Name { get; set; }
        public ISet<Guid> Wolves { get; set; }
    }
}