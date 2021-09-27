using System;

namespace WolfPack.Domian.Model.Shared.Common
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute :Attribute
    {
        
    }
}