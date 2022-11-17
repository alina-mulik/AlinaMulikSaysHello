namespace Classes8._2
{
    public class InvalidButtonException : Exception
    {
        private const string ErrorMessage = "You've pressed invalid button!";
        public InvalidButtonException() : base(ErrorMessage) { }
    }
}
