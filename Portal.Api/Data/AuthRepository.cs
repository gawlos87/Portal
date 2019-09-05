using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Models;

namespace Portal.Api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbContext;

        #region method public
        public AuthRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Login(string username, string password)
        {
            var user =  await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if(user == null)
                return null;

            if(!VerifiPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }


        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
             if(await _dbContext.Users.AnyAsync(u => u.Username == username ))
                return true;

            return false;    
        }
        #endregion
        
        #region method private
        private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        
        private bool VerifiPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
                using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                 if (computedHash[i] != passwordHash[i])
                    return false;  
                }

                return true;
            }
        }
        #endregion
    }
}