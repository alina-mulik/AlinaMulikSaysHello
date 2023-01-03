namespace Homework17.Models.JsonModels
{
    public class UserToCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public UserToCreate(string name, string email, string password, string avatar)
        {
            this.Email = email;
            this.Name = name;
            this.Password = password;
            this.Avatar = avatar;
        }
    }
}
