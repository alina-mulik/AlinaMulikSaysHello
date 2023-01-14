using Homework18.Adonet.Constants;
using Homework18.Adonet.Models;
using NUnit.Framework;

namespace Homework18.Adonet
{
    public class AdonetTests
    {
        [Test]
        public void CreateNewUserTest()
        {
            // Create a user and add user entry to the table
            var testUser = new User("Alina", 18);
            AdonetHelpers.AddEntryToTable(testUser.Name, testUser.Age);

            // Get values of added user entry of fields from the DB
            var nameFromDb = AdonetHelpers.GetLastAddedValueByRowIndexAndColumnName(UsersTableColumns.Name);
            var ageFromDb = AdonetHelpers.GetLastAddedValueByRowIndexAndColumnName(UsersTableColumns.Age);

            // Compare user fields values
            Assert.AreEqual(testUser.Name, nameFromDb);
            Assert.AreEqual(testUser.Age, int.Parse(ageFromDb));
        }

        [Test]
        public void EditUserTest()
        {
            // Create a user and add user entry to the table
            var newAgeValue = "30";
            var testUser = new User("Harry", 29);
            var userId = AdonetHelpers.AddNewEntryToTheTableUsingSqlDataUpdater(testUser.Name, testUser.Age);

            // Edit entry Age value
            AdonetHelpers.EditValueByEntryIdAndColumnName(userId, UsersTableColumns.Age, newAgeValue);

            // Get Age value from DB
            var age = AdonetHelpers.GetValueByEntryIdAndColumnName(userId, UsersTableColumns.Age);

            // Check that value was really edited
            Assert.AreEqual(newAgeValue, age);
        }

        [Test]
        public void DeleteUserTest()
        {
            // Create a user and add user entry to the table
            var testUser = new User("Ron", 20);
            AdonetHelpers.AddEntryToTable(testUser.Name, testUser.Age);

            // Delete entry from DB Users table
            var listOfNamesBeforeDeletion = AdonetHelpers.GetListOfValuesByEntryColumnName(UsersTableColumns.Name);
            var rowIndex = listOfNamesBeforeDeletion.Count - 1;
            AdonetHelpers.DeleteRowFromTableByRowIndex(rowIndex);

            // Get list of Names after entry deletion
            var listOfNamesAfterDeletion = AdonetHelpers.GetListOfValuesByEntryColumnName(UsersTableColumns.Name);

            // Check that deleted entry Name is not there
            Assert.IsTrue(!listOfNamesAfterDeletion.Contains(testUser.Name));
        }
    }
}
