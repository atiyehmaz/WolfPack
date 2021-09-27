using System;

namespace WolfPack.Application.Packs.Commands
{
    public class AddWolfToPackCommand
    {
        public Guid Id { get; set; }

        public Guid Wolf { get; set; }
    }
}