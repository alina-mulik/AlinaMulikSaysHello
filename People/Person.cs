namespace People
{
    public class Person
    {
        private string _name;
        private int _age;
        private int _id;
        private string _gender;
        protected string Name { get { return _name; } set { _name = value; } }
        protected string Gender { get { return _gender; } set { _gender = value; } }
        protected int Age { get { return _age; } set { _age = value; } }
        protected int Id { get { return _id; } set { _id = value; } }

        public Person(string name, int age, int id, string gender)
        {
            Name = name;
            Gender = gender.ToLower();
            Age = age;
            Id = id;
        }

        public string GetName()
        {
            if (_gender.ToLower() == "female")
            {
                return "Mrs. " + _name;
            }
            if (_gender.ToLower() == "male")
            {
                return "Mr. " + _name;
            }

            return _name;
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
