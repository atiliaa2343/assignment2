namespace PasswordStrengthLib;

public class PasswordCheck
{
    int count = 0; 
    public void CheckPasswordStrength(string password)
    { 
        int count = 0;
        for (int counter = 0; counter < password.Length; counter++)
        {
            char current_character = password[counter];
            if (Char.IsUpper(current_character) == true)
            {
                counter += 1;
            }
             
        }
    }
}
