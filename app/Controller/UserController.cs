using System;
using Model;
using Helper;

namespace Controller
{
    public class UserController
    {
        public UserController() {}

        public static bool Authenticate(string email, string password)
        {
            if (Validation.IsEmail(email))
            {
                User user_model = User.Find(email);
                if (user_model != null) return user_model.ValidatePassword(password);
            }
            return false;
        }

        public static bool CreateUser(string username, string email, string password, int permission_id)
        {
            bool isSave = false;
            if (Validation.IsEmail(email))
            {
                User user_model = new User(username, email, password, permission_id);
                isSave = user_model.Save();
            }
            return isSave;
        }
    }
}