using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
     public class AccountService : IAccountService
     {
          private readonly IUserRepository _userRepository;
          public AccountService(IUserRepository userRepository)
          {
               _userRepository = userRepository;
          }
          public int RegisterUser(UserRegisterRequestModel model)
          {
               // make sure the email user entered does not exist in our database
               var dbUser = _userRepository.GetUserByEmail(model.Email);
               if (dbUser != null)
               {
                    //return 0
                    throw new Exception("Email already exists and please check!");
               }

               // continue with registration
               // create a unique salt
               var salt = generateSalt();

               // hash the password with the salt created above
               var hashedPassword = getHashedPassword(model.Password, salt);

               var user = new User
               {
                    Email = model.Email,
                    HashedPassword = hashedPassword,
                    Salt = salt,
                    DateOfBirth = model.DateOfBirth,
                    FirstName = model.FirstName,
                    LastName = model.LastName
               };

               var createdUser = _userRepository.Add(user);
               return createdUser.Id;
               // save to the database
               // reutn back

          }

          public UserLoginResponseModel ValidateUser(LoginRequestModel model)
          {
                 throw new NotImplementedException();
          }

          private string generateSalt()
        {
               byte[] randomBytes = new byte[128/8];
               using (var rng = RandomNumberGenerator.Create())
            {
                    rng.GetBytes(randomBytes);
            }
               return Convert.ToBase64String(randomBytes);
        }

          private string getHashedPassword(string password, string salt)
        {
               var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                    password: password,
                                                                    salt: Convert.FromBase64String(salt),
                                                                    prf: KeyDerivationPrf.HMACSHA512,
                                                                    iterationCount: 10000,
                                                                    numBytesRequested: 256 / 8));
               return hashed;
          }
     }
}
