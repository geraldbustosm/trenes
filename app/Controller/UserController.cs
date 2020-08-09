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
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public static bool CreateUser(string username, string email, string password)
        {
            try
            {
                User user_model = new User(username, email, password);
                if (user_model.CheckIfUserExists()) throw new Exception("El usuario ya existe en la base de datos!");
                user_model.Save();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
