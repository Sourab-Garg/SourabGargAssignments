namespace UpperCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");
            string input = Console.ReadLine();
            string ans = "";

            for(int i = 0;i<input.Length; i++)
            {
                if(i == 0)
                {
                    ans += char.ToUpper(input[i]);
                    continue;
                }
                if (input[i-1] == ' ' && input[i] != ' ')
                {
                    ans += char.ToUpper(input[i]);
                    continue;
                }
                ans += input[i];
            }
            Console.WriteLine(ans);


            Console.ReadLine();
        }
    }
}
