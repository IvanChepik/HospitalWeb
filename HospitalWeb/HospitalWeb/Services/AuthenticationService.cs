using HospitalDataAccess.Models.UserModels;
using HospitalWeb.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using HospitalWeb.Extensions.Identity;

namespace HospitalWeb.Services
{
    public class AuthenticationService<TUser> where TUser : User, new()
    {
        protected readonly UserManager<TUser> userManager;
        protected readonly JwtManager jwtManager;

        public AuthenticationService(JwtManager jwtManager, UserManager<TUser> userManager)
        {
            this.userManager = userManager;
            this.jwtManager = jwtManager;
        }

        public async Task<AuthResult<Token>> Login(LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                return AuthResult<Token>.UnvalidatedResult;

            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user != null)
            {
                if (await userManager.CheckPasswordAsync(user, loginDto.Password))
                {
                    var token = jwtManager.GenerateToken(user);
                    return AuthResult<Token>.TokenResult(token);
                }
            }

            return AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<AuthResult<Token>> ChangePassword(ChangePasswordDTO changePasswordDto, string currentUserId)
        {
            if (changePasswordDto == null ||
                string.IsNullOrEmpty(changePasswordDto.ConfirmPassword) ||
                string.IsNullOrEmpty(changePasswordDto.Password) ||
                changePasswordDto.Password != changePasswordDto.ConfirmPassword
            )
                return AuthResult<Token>.UnvalidatedResult;


            var user = await userManager.FindByIdAsync(currentUserId.ToString());
            var result = await userManager.ChangePasswordAsync(user, null, changePasswordDto.Password);
            if (result.Succeeded)
                return AuthResult<Token>.SucceededResult;


            return AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<AuthResult<Token>> SignUp(SignUpDTO signUpDto)
        {
            try
            {
                if (signUpDto == null ||
                    string.IsNullOrEmpty(signUpDto.Email) ||
                    string.IsNullOrEmpty(signUpDto.Password) ||
                    string.IsNullOrEmpty(signUpDto.ConfirmPassword) ||
                    string.IsNullOrEmpty(signUpDto.FirstName) ||
                    string.IsNullOrEmpty(signUpDto.LastName) ||
                    signUpDto.Password != signUpDto.ConfirmPassword
                )
                    return AuthResult<Token>.UnvalidatedResult;


                var newUser = new TUser
                    {SecondName = signUpDto.LastName, FirstName = signUpDto.FirstName, Email = signUpDto.Email, UserName = signUpDto.Email};

                var result = await userManager.CreateAsync(newUser, signUpDto.Password);

                if (result.Succeeded)
                {
                    //await userManager.AddToRoleAsync(newUser, "User");
                    var token = jwtManager.GenerateToken(newUser);
                    return AuthResult<Token>.TokenResult(token);
                }

                return AuthResult<Token>.UnauthorizedResult;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
            
        }

        public async Task<AuthResult<string>> RequestPassword(RequestPasswordDTO requestPasswordDto)
        {
            if (requestPasswordDto == null ||
                string.IsNullOrEmpty(requestPasswordDto.Email))
                return  AuthResult<string>.UnvalidatedResult;

            var user = await userManager.FindByEmailAsync(requestPasswordDto.Email);

            if (user != null)
            {
                var passwordResetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                return  AuthResult<string>.TokenResult(passwordResetToken);
            }

            return  AuthResult<string>.UnvalidatedResult;
        }

        public async Task< AuthResult<Token>> RestorePassword(RestorePasswordDTO restorePasswordDto)
        {
            if (restorePasswordDto == null ||
                string.IsNullOrEmpty(restorePasswordDto.Email) ||
                string.IsNullOrEmpty(restorePasswordDto.Token) ||
                string.IsNullOrEmpty(restorePasswordDto.NewPassword) ||
                string.IsNullOrEmpty(restorePasswordDto.ConfirmPassword) ||
                string.IsNullOrEmpty(restorePasswordDto.ConfirmPassword) ||
                restorePasswordDto.ConfirmPassword != restorePasswordDto.NewPassword
            )
                return  AuthResult<Token>.UnvalidatedResult;

            var user = await userManager.FindByEmailAsync(restorePasswordDto.Email);

            if (user != null)
            {
                var result = await userManager.ResetPasswordAsync(user, restorePasswordDto.Token, restorePasswordDto.NewPassword);

                if (result.Succeeded)
                {
                    var token = jwtManager.GenerateToken(user);
                    return  AuthResult<Token>.TokenResult(token);
                }
            }

            return  AuthResult<Token>.UnvalidatedResult;
        }

        public Task< AuthResult<Token>> SignOut()
        {
            throw new System.NotImplementedException();
        }

        public async Task< AuthResult<Token>> RefreshToken(RefreshTokenDTO refreshTokenDto)
        {
            var refreshToken = refreshTokenDto?.Token?.Refresh_token;
            if (string.IsNullOrEmpty(refreshToken))
                return  AuthResult<Token>.UnvalidatedResult;

            try
            {
                var principal = jwtManager.GetPrincipal(refreshToken, isAccessToken: false);
                var userId = principal.GetUserId();
                var user = await userManager.FindByIdAsync(userId.ToString());

                if (user != null)
                {
                    var token = jwtManager.GenerateToken(user);
                    return  AuthResult<Token>.TokenResult(token);
                }
            }
            catch (Exception)
            {
                return  AuthResult<Token>.UnauthorizedResult;
            }

            return  AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<Token> GenerateToken(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                return jwtManager.GenerateToken(user);
            }

            return null;
        }
    }
}