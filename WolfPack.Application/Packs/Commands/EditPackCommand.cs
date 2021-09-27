using System;
using System.Collections.Generic;

namespace WolfPack.Application.Packs.Commands
{
    public class EditPackCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ISet<Guid> Wolves { get; set; }
    }
}