namespace GenericsClasses
{
    public abstract class Human
    {
        protected string? FirstName;
        protected string? LastName;
        public abstract string? HumanFistName { get; set; }
        public abstract string? HumanLastName { get; set; }
        public Human(string? firstName, string? lastName)
        {
            HumanFistName = firstName;
            HumanLastName = lastName;
        }
        public Human()
        {
            HumanFistName = "Default";
            HumanLastName = "Human";
        }
    }
}
