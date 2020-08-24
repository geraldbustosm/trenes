using System;
using Model;
using Helper;

namespace Controller
{
    public static class UserController
    {

        public static bool Authenticate(string email, string password)
        {
            if (Validation.IsEmail(email))
            {
                User user = User.Find(email);
                if (user != null) return Validation.VerifyPassword(user.password, password);
            }
            return false;
        }

        public static bool CreateUser(string username, string email, string password, int permission_id)
        {
            string hashingPassword = Validation.hash(password);
            User user_model = new User(username, email, hashingPassword, permission_id);
            return user_model.Save();
        }
    }
}