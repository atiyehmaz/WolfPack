using System;
using System.Collections.Generic;

namespace WolfPack.Contract.Packs.Commands
{
    public class CreatePackCommandDto
    {
        public string Name { get; set; }
        public ISet<Guid> Wolves { get; set; }
    }
}