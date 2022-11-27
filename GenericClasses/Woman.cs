namespace GenericsClasses
{
    public class Woman : Human
    {
        public override string? HumanFistName { get => FirstName; set => FirstName = value; }
        public override string? HumanLastName { get => LastName; set => LastName = value; }
        public Woman(string? firstName, string? lastName) : base(firstName, lastName)
        {
            HumanFistName = firstName;
            HumanLastName = lastName;
        }
        public Woman() : this("Ann", "Doe")
        {
        }
    }
}
