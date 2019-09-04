using System;
using System.Text;
using System.Threading.Tasks;
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
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
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

        public Task<bool> UserExists(string uesername)
        {
            throw new System.NotImplementedException();
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
        #endregion
    }
}