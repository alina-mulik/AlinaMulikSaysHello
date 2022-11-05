using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetName()
        {
            return name;
        }
    }
}
