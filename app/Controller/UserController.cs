using Model;

namespace Controller
{
    public class UserController
    {
        public UserController() {}

        public static bool Authenticate(string email, string password)
        {
            User user_model = User.Find(email);
            if (user_model != null) return user_model.ValidatePassword(password);
            return false;
        }
    }
}
