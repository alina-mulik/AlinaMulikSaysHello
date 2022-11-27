namespace GenericsClasses
{
    public class Man : Human
    {
        public override string HumanFistName { get => FirstName; set => FirstName = value; }
        public override string HumanLastName { get => LastName; set => LastName = value; }

        public Man(string? firstName, string? lastName) : base(firstName, lastName)
        {
            HumanFistName = firstName;
            HumanLastName = lastName;
        }
        public Man() : this("John", "Doe")
        {
        }
    }
}
