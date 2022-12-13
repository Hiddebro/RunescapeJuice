namespace Business_logic_Layer.Models
{
    public class User_Model
    {
        public int User_ID { get; set; }
        public int IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User_Model(int isadmin, string username, string password)
        {
            IsAdmin = isadmin;
            Username = username;
            Password = password;
        }

        public User_Model(int user_ID, int isadmin)
        {
            User_ID = user_ID;
            IsAdmin = isadmin;
        }
        public User_Model(int user_ID)
        {
            User_ID = user_ID;
        }
        public User_Model(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public User_Model(int user_ID, int isAdmin, string username, string password)
        {
            User_ID = user_ID;
            IsAdmin = isAdmin;
            Username = username;
            Password = password;
        }
        public User_Model(string username, string password, int user_ID, int isAdmin)
        {
            Username = username;
            Password = password;
            User_ID = user_ID;
            IsAdmin = isAdmin;
        }

    }
}
