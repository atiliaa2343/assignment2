namespace PasswordStrengthLib;

public class PasswordCheck
{
    public string CheckPasswordStrength(string password)
    {
        bool Upper = false;
        bool Lower = false;
        bool Digit = false;
        bool Symbol = false;
        bool Pass_Length = false;

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

        if (password.Length < 8)
        {
            Pass_Length = true; 
        }

        int count = 0;
        if (Upper) count++;
        if (Lower) count++;
        if (Digit) count++;
        if (Symbol) count++;
        if (Pass_Length) count++;

        if (count == 0)
            return "INELIGIBLE";
        else if (count == 1)
            return "WEAK";
        else if (count == 2 || count == 3 || count == 4) 
            return "MEDIUM";
        else
            return "STRONG";
    }
}

