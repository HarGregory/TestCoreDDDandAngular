namespace PromoMashTest.Server.Core.ValueObjects
{
    public class Password
    {
        public string Value { get; private set; }

        private Password() { }

        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6 || !password.Any(char.IsDigit) || !password.Any(char.IsLetter))
            {
                throw new ArgumentException("Password must be at least 6 characters long, contain at least one letter and one digit.");
            }

            Value = password;
        }
    }
}
