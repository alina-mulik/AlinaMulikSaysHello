using System.Net;
using Homework17.Helpers;
using Homework17.Models.JsonModels;
using Homework17.Services;
using NUnit.Framework;

namespace Homework17.Tests
{
    public class UsersTests
    {
        private const string EmailPart = "@gmail.com";
        private const string AvatarUrl = "https://www.pinterest.com/pin/581668108095603898/";

        [Test]
        public void CreateNewUser()
        {
            // Create a User To Create instance
            var name = RandomHelper.GetRandomString(6);
            var email = RandomHelper.GetRandomString(6) + EmailPart;
            var password = RandomHelper.GetRandomString(8);
            var userToCreate = new UserToCreate(name, email, password, AvatarUrl);

            // Count all users before new user creation
            var getAllUsersBeforeCreationCount = StoreService.GetAllUsersInfo().Count;

            // Create user it took and get new user Id
            var createdUser = StoreService.CreateUser(userToCreate);
            var currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            Assert.AreEqual(HttpStatusCode.Created, createdUser.StatusCode);
            var id = createdUser.ResponseModel.Id;

            // Count all users after new user creation and compare counts
            var getAllUsersAfterCreation = StoreService.GetAllUsersInfo();
            var getAllUsersAfterTheCreationCount = getAllUsersAfterCreation.Count;
            Assert.AreNotEqual(getAllUsersAfterTheCreationCount, getAllUsersBeforeCreationCount);

            // Check that Name of newly-created user exists in the list of users
            var listOfUserNames = getAllUsersAfterCreation.Select(x => x.Name).ToList();
            Assert.IsTrue(listOfUserNames.Contains(userToCreate.Name));

            // Check that the request can be send to the new user using it's Id, get and check some of the user properties
            var user = StoreService.GetUserInfo(id);
            Assert.AreEqual(HttpStatusCode.OK, user.StatusCode);
            var userCreatedAt = user.ResponseModel.CreationAt.ToString("yyyy-MM-dd HH:mm");
            Assert.AreEqual(currentDateTime, userCreatedAt);
            Assert.AreEqual(userToCreate.Name, user.ResponseModel.Name);
        }

        [Test]
        public void DeleteUser()
        {
            // Precondition: create user to delete in future and get it's Id
            var name = RandomHelper.GetRandomString(6);
            var email = RandomHelper.GetRandomString(6) + EmailPart;
            var password = RandomHelper.GetRandomString(8);
            var userToCreate = new UserToCreate(name, email, password, AvatarUrl);
            var createdUser = StoreService.CreateUser(userToCreate);
            var id = createdUser.ResponseModel.Id;

            // Check that user really exists by sending request to get it's info
            var user = StoreService.GetUserInfo(id);
            Assert.AreEqual(userToCreate.Name, user.ResponseModel.Name);
            Assert.AreEqual(userToCreate.Email, user.ResponseModel.Email);

            // Delete the user
            var deletedUser = StoreService.DeleteUser(id);
            Assert.AreEqual(HttpStatusCode.OK, deletedUser.StatusCode);

            // Send request using deleted user Id and check status code
            var notExistingUser = StoreService.GetUserInfo(id);
            Assert.AreEqual(HttpStatusCode.BadRequest, notExistingUser.StatusCode);
        }

        [Test]
        public void EditUser()
        {
            // Precondition: create user to delete in future and get it's Id
            var name = RandomHelper.GetRandomString(6);
            var email = RandomHelper.GetRandomString(6) + EmailPart;
            var password = RandomHelper.GetRandomString(8);
            var userToCreate = new UserToCreate(name, email, password, AvatarUrl);
            var createdUser = StoreService.CreateUser(userToCreate);
            var id = createdUser.ResponseModel.Id;

            // Check that user really exists by senfing request to get it's info and check Name and Email values
            var user = StoreService.GetUserInfo(id);
            Assert.AreEqual(userToCreate.Name, user.ResponseModel.Name);
            Assert.AreEqual(userToCreate.Email, user.ResponseModel.Email);

            // Update created user Email and Name and check values we got from the response
            userToCreate.Name = RandomHelper.GetRandomString(6);
            userToCreate.Email = RandomHelper.GetRandomString(6) + EmailPart;
            var updatedUser = StoreService.UpdateUser(userToCreate, id);
            Assert.AreEqual(HttpStatusCode.OK, updatedUser.StatusCode);
            Assert.AreEqual(userToCreate.Name, updatedUser.ResponseModel.Name);
            Assert.AreEqual(userToCreate.Email, updatedUser.ResponseModel.Email);
        }
    }
}
