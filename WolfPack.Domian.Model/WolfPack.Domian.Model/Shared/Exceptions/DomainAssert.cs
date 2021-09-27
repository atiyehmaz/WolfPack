
using System;
using WolfPack.Domian.Model.Wolves;

namespace WolfPack.Domian.Model.Shared.Exceptions
{
    public static class DomainAssert
    {
        public static void LengthNotGreaterThan(string property, int maxLength, string validationMessage)
        {
            if (property.Length <= maxLength) return;
            throw new DomainException(validationMessage);

        }
        
        public  static  void NotNullOrWhitespace(string property, string validationMessage)
        {
            if (String.IsNullOrWhiteSpace(property))
            {
                throw new DomainException(validationMessage);
            }
        }
    }
}