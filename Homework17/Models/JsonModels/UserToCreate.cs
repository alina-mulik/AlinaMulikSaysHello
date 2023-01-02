namespace Homework17.Models.JsonModels
{
    public class UserToCreate
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }

        public UserToCreate(string name, string email, string password, string avatar)
        {
            this.email = email;
            this.name = name;
            this.password = password;
            this.avatar = avatar;
        }
    }
}
