namespace PasswordStrengthLib
{
    public class PasswordCheck
    {
        /// <summary>
        /// Evaluates the strength of a given password based on the presence of uppercase letters, lowercase letters, digits, and symbols.
        /// The function iterates through each character in the password and checks for these character types.
        /// The strength is determined by how many of these categories are present:
        /// 0 = INELIGIBLE, 1 = WEAK, 2 or 3 = MEDIUM, 4 = STRONG.
        /// </summary>
        /// <param name="password">The password string to be evaluated.</param>
        /// <returns>A string indicating the password strength: "INELIGIBLE", "WEAK", "MEDIUM", or "STRONG".</returns>
        public string CheckPasswordStrength(string password)
        {
            bool Upper = false;
            bool Lower = false;
            bool Digit = false;
            bool Symbol = false;
            for (int counter = 0; counter < password.Length; counter++)
            {
                char current_character = password[counter];
                if (Char.IsUpper(current_character))
                {
                    Upper = true;
                }
                else if (Char.IsLower(current_character))
                {
                    Lower = true;
                }
                else if (Char.IsDigit(current_character))
                {
                    Digit = true;
                }
                else
                {
                    Symbol = true;
                }
            }
            int count = 0;
            if (Upper) count++;
            if (Lower) count++;
            if (Digit) count++;
            if (Symbol) count++;
            if (count == 0)
                return "INELIGIBLE";
            else if (count == 1)
                return "WEAK";
            else if (count == 2 || count == 3)
                return "MEDIUM";
            else
                return "STRONG";
        }

    

        /// <summary>
        /// Generates a valid version 4 UUID (Universally Unique Identifier).
        /// Uses System.Guid.NewGuid() to create a random UUID conforming to RFC 4122.
        /// </summary>
        /// <returns>A string representation of a version 4 UUID.</returns>
        public string GenerateUuidV4()
        {
            return Guid.NewGuid().ToString();
        }
}

}

