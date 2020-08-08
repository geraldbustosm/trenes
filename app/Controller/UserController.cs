using System;
using Model;

namespace Controller
{
    public class UserController
    {
        public UserController() {}

        public static bool Authenticate(string email, string password)
        {

            try
            {
                User user_model = User.Find(email);
                if (user_model != null) return user_model.ValidatePassword(password);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }
    }
}
