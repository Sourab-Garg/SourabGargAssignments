namespace AirthmeticOpsAndAnother
{
    public class Calculate
    {
        public int Addition(int num1, int num2)
        {
            return num1 + num2;
        }
        public int substract(int num1, int num2)
        {
            int result;
            if (num1 > num2)
            {
                result = num1 - num2;
            }
            else
            {
                result = num2 - num1;
            }
            return result;
        }
        public int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Divide(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
            return result;
        }
        public int GetPasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return 0;

            int score = 0;
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            string specialChars = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";

            if (password.Length >= 8) score++;  

            foreach (char c in password)
            {
                if (!hasUpper && char.IsUpper(c)) { hasUpper = true; score++; }
                if (!hasLower && char.IsLower(c)) { hasLower = true; score++; }
                if (!hasDigit && char.IsDigit(c)) { hasDigit = true; score++; }
                if (!hasSpecial && specialChars.Contains(c)) { hasSpecial = true; score++; }
            }

            return score;
        }


    }
}
