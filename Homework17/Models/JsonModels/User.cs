namespace Homework17.Models.JsonModels
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string avatar { get; set; }
        public DateTime creationAt { get; }
        public DateTime updatedAt { get; }
    }
}
