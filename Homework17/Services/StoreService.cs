using Homework17.HttpClients;
using Homework17.Models;
using Homework17.Models.JsonModels;
using Newtonsoft.Json;

namespace Homework17.Services
{
    public class StoreService
    {
        private const string BaseUri = "https://api.escuelajs.co/api/v1";

        public static RestResponse<User> GetUserInfo(int id) =>
            BasicHttpClient.PerformGetRequest<User>($"{BaseUri}/users/{id}", null);

        public static RestResponse<User> CreateUser(UserToCreate userToCreate)=>
            BasicHttpClient.PerformPostRequest<UserToCreate, User>($"{BaseUri}/users", userToCreate, null);

        public static RestResponse<User> UpdateUser(UserToCreate updatedUserModel, int id) =>
            BasicHttpClient.PerformPutRequest<UserToCreate, User>($"{BaseUri}/users/{id}", updatedUserModel, null);

        public static RestResponse DeleteUser(int id) =>
            BasicHttpClient.PerformDeleteRequest($"{BaseUri}/users/{id}", null);

        public static List<User> GetAllUsersInfo()
        {
            var allUsers = BasicHttpClient.PerformGetRequest($"{BaseUri}/users", null).ResponseData;
            var allUsersList = JsonConvert.DeserializeObject<List<User>>(allUsers);

            return allUsersList;
        }
    }
}
