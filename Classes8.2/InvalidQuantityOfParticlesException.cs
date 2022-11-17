namespace Classes8._2
{
    public class InvalidQuantityOfParticlesException : Exception
    {
        private const string ErrorMessage = "ALARM! Invalid quantity of particles! Can't continue!";
        public InvalidQuantityOfParticlesException() : base(ErrorMessage) { }
    }
}
