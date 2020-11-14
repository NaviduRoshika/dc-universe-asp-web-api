using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace alone_mysql_dc_comics.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DcDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DcDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;  //to enter appsettings json file
            _context = context;

        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PaswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password";
            }
            else
            {
                response.Data = await CreateTokenAsync(user);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                if (await UserExists(user.UserName))
                {
                    response.Success = false;
                    response.Message = "User already exists";
                }
                else
                {
                    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PaswordSalt = passwordSalt;
                    user.PasswordHash = passwordHash;

                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    response.Data = user.Id;
                }

            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        private async Task<string> CreateTokenAsync(User user)
        {
            Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == user.RoleId);
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,userRole.Name)
            };

            //encode secret key
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            
            //define signature algorithem
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //get data to crete token
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            //crete token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
             
            //convert to string
            return tokenHandler.WriteToken(token);
        }
    }
}