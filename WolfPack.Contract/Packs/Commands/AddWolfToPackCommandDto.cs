using System;

namespace WolfPack.Contract.Packs.Commands
{
    public class AddWolfToPackCommandDto
    {
        public Guid Id { get; set; }

        public Guid Wolf { get; set; }
    }
}