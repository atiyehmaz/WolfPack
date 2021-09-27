using System;
using System.Collections.Generic;

namespace WolfPack.Contract.Packs.Commands
{
    public class EditPackCommandDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ISet<Guid> Wolves { get; set; }
    }
}