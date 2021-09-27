namespace WolfPack.Domian.Model.Shared.Exceptions
{
    public class DomainException : BaseException
    {
        public string ValidationMessage { get; set; }

        public DomainException(string validationMessage)
        {
            ValidationMessage = validationMessage;
        }
    }
}