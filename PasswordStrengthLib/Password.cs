namespace PasswordStrengthLib;

public class PasswordCheck
{
    public string CheckPasswordStrength(string password)
    {
        bool hasUpper = false;


        for (int counter = 0; counter < password.Length; counter++)
        {
            char current_character = password[counter];

            if (Char.IsUpper(current_character))
            {
                hasUpper = true;
            }


        }
    }
}

