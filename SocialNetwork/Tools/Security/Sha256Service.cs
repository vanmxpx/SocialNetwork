using System.Security.Cryptography;
using System.Text;
namespace SocialNetwork.Services
{
    public static class Sha256Service
    {
        public static string Convert(string rawString)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                rawString = rawString.ToUpper();
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawString));

                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString(); 
            }
        }
    }
}