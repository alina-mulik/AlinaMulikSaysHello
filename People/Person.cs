namespace People
{
    public class Person
    {
        private string name;
        private int age;
        private int id;
        private string gender;
        protected string Name { get { return name; } set { name = value; } }
        protected string Gender { get { return gender; } set { gender = value; } }
        protected int Age { get { return age; } set { age = value; } }
        protected int Id { get { return id; } set { id = value; } }

        public Person(string name, int age, int id, string gender)
        {
            Name = name;
            Gender = gender.ToLower();
            Age = age;
            Id = id;
        }

        public string GetName()
        {
            if (gender.ToLower() == "female")
            {
                return "Mrs. " + name;
            }
            else if (gender.ToLower() == "male")
            {
                return "Mr. " + name;
            }
            else
            {
                return name;
            }
        }

        public static string[] GetArrayOfNames(Person[] array)
        {
            var arrayOfNames = new string[array.Length];
            var counter = 0;
            foreach (var item in array)
            {
                arrayOfNames[counter] = item.GetName();
                counter++;
            }

            return arrayOfNames;
        }
    }
}
