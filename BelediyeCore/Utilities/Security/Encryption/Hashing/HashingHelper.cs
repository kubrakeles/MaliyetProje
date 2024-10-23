using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeCore.Utilities.Security.Encryption.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(String password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));

            }
        }
        public static bool VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt) //daha önce kaydedilen şifreyi kontrol şifre
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

            }
            return true;

        }
    }
}
