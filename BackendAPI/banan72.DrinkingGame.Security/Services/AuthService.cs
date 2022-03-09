﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using banan72.DrinkingGame.Core;
using banan72.DrinkingGame.Security.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace banan72.DrinkingGame.Security.Services
{
    
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AuthDbContext _authctx;
        
        public AuthService(IConfiguration configuration,AuthDbContext ctx)
        {
            _configuration = configuration;
            _authctx = ctx;
        }
        
        public LoginUser IsValidUserInformation(LoginUser user)
        {
            return _authctx.LoginUsers.FirstOrDefault(u => u.UserName.Equals(user.UserName) &&
                                                           u.HashedPassword.Equals(user.HashedPassword));
         }
         
         public string GenerateJwtToken(LoginUser user)
         {
             var userFound = IsValidUserInformation(user);
             if (userFound == null) return null;

             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
                     new Claim("Id", userFound.Id.ToString()),
                     new Claim("UserName", userFound.UserName)
                 }),
                 Expires = DateTime.UtcNow.AddMinutes(30),
                 Issuer = _configuration["Jwt:Issuer"],
                 Audience = _configuration["Jwt:Audience"],
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             return tokenHandler.WriteToken(token);
         }
         
         //Hashing method used ONLY for logging in a preexisting user 
         public string Hash(LoginUser user)
         {
             var userFromDb = _authctx.LoginUsers.FirstOrDefault(u => u.UserName.Equals(user.UserName));
             byte[] saltedByte = Encoding.ASCII.GetBytes(userFromDb.Salt);
             user.HashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                 password: user.HashedPassword,
                 salt: saltedByte,
                 prf: KeyDerivationPrf.HMACSHA256,
                 iterationCount: 100000,
                 numBytesRequested: 256 / 8));
             return user.HashedPassword;
         }
         //Hashing method used when creating a new account
         public string HashNewPassword(string newPassword, string salt)
         {
             byte[] saltedByte = Encoding.ASCII.GetBytes(salt);
             var hashedNewPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                 password: newPassword,
                 salt: saltedByte,
                 prf: KeyDerivationPrf.HMACSHA256,
                 iterationCount: 100000,
                 numBytesRequested: 256 / 8));
             return hashedNewPassword;
         }
         public List<Permission> GetPermissions(int userId)
         {
             return _authctx.UserPermissions
                 .Include(up => up.Permission)
                 .Where(up => up.UserID == userId)
                 .Select(up => up.Permission)
                 .ToList();
         }
         
         //Vores account skal have samme fields som fra exam projekt
         public string CreateNewAccount(LoginUser newUser, Player userAccount)
         {
             var generatedSalt = GenerateSalt();
             var hashedNewPassword = HashNewPassword(newUser.HashedPassword, generatedSalt);
             var newAccount = _authctx.Add(new LoginUser
             {
                 UserName = newUser.UserName,
                 HashedPassword = hashedNewPassword,
                 Salt = generatedSalt,
                 AccountId = userAccount.id
             }).Entity;
             _authctx.SaveChanges();
             return "Success!";
         }
         public string GenerateSalt()
         {
             var random = new Random();
             var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
             return new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
         }
         
         public void EstablishPermissions(Player newAccount)
         {
             var username = newAccount.name;
             var createdLoginUser = _authctx.LoginUsers.Where(lu => lu.UserName == username)
                 .FirstOrDefault();
             if (newAccount.Type == "Customer")
             {
                 _authctx.UserPermissions.Add(new UserPermission
                 {
                     UserID = createdLoginUser.Id,
                     PermissionId = 3
                 });
                 _authctx.SaveChanges();
             }
             if (newAccount.Type == "Employee")
             {
                 _authctx.UserPermissions.AddRange(new UserPermission
                 {
                     UserID = createdLoginUser.Id,
                     PermissionId = 3
                 }, new UserPermission
                 {
                     UserID = createdLoginUser.Id,
                     PermissionId = 2
                 });
                 _authctx.SaveChanges();
             }
             if (newAccount.Type == "Admin")
             {
                 _authctx.UserPermissions.AddRange(new UserPermission
                 {
                     UserID = createdLoginUser.Id,
                     PermissionId = 3
                 }, new UserPermission
                 {
                     UserID = createdLoginUser.Id,
                     PermissionId = 2
                 }, new UserPermission
                 {
                     UserID = createdLoginUser.Id,
                     PermissionId = 1
                 });
                 _authctx.SaveChanges();
             }
             else if(newAccount.Type != "Admin" && newAccount.Type != "Employee" && newAccount.Type != "Customer")
             {
                 throw new InvalidDataException("Invalid account type");
             }
         }
         
         public LoginUser GetUserInfo(string username)
         {
             return _authctx.LoginUsers.Where(lu => lu.UserName == username)
                 .FirstOrDefault();
         }
    }
}