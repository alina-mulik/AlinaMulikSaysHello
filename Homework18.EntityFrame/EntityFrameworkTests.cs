using NUnit.Framework;
using System.Linq;

namespace Homework18.EntityFrame
{
    public class EntityFrameworkTests
    {
        [Test]
        public void CreateNewUserTest()
        {
            // Create a user and add user entry to the table
            var testUser = new User() { Age = 18, Name = "Alina", CreatedDate = System.DateTime.Now };
            EntityFrameworkHelpers.AddUserToUsersTable(testUser);

            // Get values of added user entry of fields from the DB
            var nameFromDb = EntityFrameworkHelpers.GetEntityFrameworkDbInstance(context => context.Users.Where(x => x.Name == testUser.Name))[0].Name;
            var ageFromDb = EntityFrameworkHelpers.GetEntityFrameworkDbInstance(context => context.Users.Where(x => x.Name == testUser.Name))[0].Age;

            // Compare user fields values
            Assert.AreEqual(testUser.Name, nameFromDb);
            Assert.AreEqual(testUser.Age, ageFromDb);
        }

        [Test]
        public void EditUserTest()
        {
            // Create a user and add user entry to the table
            var newAgeValue = 30;
            var testUser = new User() { Age = 29, Name = "Harry", CreatedDate = System.DateTime.Now };
            EntityFrameworkHelpers.AddUserToUsersTable(testUser);

            // Edit entry Age value
            EntityFrameworkHelpers.EditUserAgeInUsersTableByUserId(testUser.Id, newAgeValue);

            // Get Age value from DB
            var age = EntityFrameworkHelpers.GetEntityFrameworkDbInstance(context => context.Users.Where(x => x.Name == testUser.Name))[0].Age;

            // Check that value was really edited
            Assert.AreEqual(newAgeValue, age);
        }

        [Test]
        public void DeleteUserTest()
        {
            // Create a user and add user entry to the table
            var newAgeValue = 30;
            var testUser = new User() { Age = 20, Name = "Ron", CreatedDate = System.DateTime.Now };
            EntityFrameworkHelpers.AddUserToUsersTable(testUser);

            // Delete entry from DB Users table
            EntityFrameworkHelpers.DeleteUserFromUsersTable(testUser);

            // Get list of users after entry deletion
            var listOfNamesAfterDeletion = EntityFrameworkHelpers.GetEntityFrameworkDbInstance(context => context.Users);

            // Check that deleted entry Name is not there
            Assert.IsTrue(!listOfNamesAfterDeletion.Contains(testUser));
        }
    }
}
