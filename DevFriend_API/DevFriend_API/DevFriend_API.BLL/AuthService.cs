using DevFriend_API.DevFriend_API.BLL.Interface;
using DevFriend_API.Entities;
using DevFriend_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFriend_API.DevFriend_API.BLL
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;
        private IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork, IAuthRepository authRepository)
        {
            _authRepository = authRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Login(string username, string password)
        {
            try
            {
                var user = await _authRepository.GetUserByName(username);

                if (user == null)
                    return null;

                if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] == passwordHash[i])
                            return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _authRepository.Add(user);
                await _unitOfWork.Commit();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> UserExist(string username)
        {
            var obj = await _authRepository.GetUserByName(username);
            if (obj !=null)
            {
                return true;
            }
            return false;
        }
    }
}
