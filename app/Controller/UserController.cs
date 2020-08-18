using System;
using Model;

namespace Controller
{
    public class UserController
    {
        public UserController() {}

        public static bool Authenticate(string username, string password)
        {
            User user_model = User.Find(username);
            if (user_model != null) return user_model.ValidatePassword(password);
            return false;
        }

        public static bool CreateUser(string username, string email, string password)
        {
            User user_model = new User(username, email, password);
            if (!user_model.CheckIfExists()) { user_model.Save(); return true; } return false;
        }
    }
}