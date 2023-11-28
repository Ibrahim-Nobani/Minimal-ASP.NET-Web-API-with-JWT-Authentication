using Microsoft.IdentityModel.Tokens;
using MinimalWebApi.Models;
namespace MinimalWebApi.Authorization;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(UserAuth user);
    Task<TokenValidationResult> ValidateTokenAsync(string token);
}