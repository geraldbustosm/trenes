using System.Text.RegularExpressions;

namespace Helper
{
    public static class Validation
    {
        public static bool IsEmail(string email)
        {
            string expresion = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            Regex automata = new Regex(expresion);
            return automata.IsMatch(email);
        }
    }
}
