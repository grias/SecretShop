using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InnoShop.UsersManagementService.Infrastructure.JwtTokenGenerators;

public class JwtPasswordRecoveryTokenService(IConfiguration _configuration) : IRecoveryTokenGenerator, IRecoveryTokenValidator
{
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("purpose", "password_recovery")
            };

        var replayAttackGuardedKeyStr = user.PasswordHash + _configuration.GetValue<string>("InnoShopAuth:Token")!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(replayAttackGuardedKeyStr));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("InnoShopAuth:Issuer"),
            audience: _configuration.GetValue<string>("InnoShopAuth:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public int? ReadUserIdWithoutValidation(string token)
    {
        if (String.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(token))
            {
                return null;
            }

            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim is null)
            {
                return null;
            }

            if (int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    public ClaimsPrincipal? ValidateToken(string token, User user)
    {
        if (string.IsNullOrWhiteSpace(token) || user == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();

        var replayAttackGuardedKeyStr = user.PasswordHash + _configuration.GetValue<string>("InnoShopAuth:Token")!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(replayAttackGuardedKeyStr));

       
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,

            ValidateIssuer = true,
            ValidIssuer = _configuration.GetValue<string>("InnoShopAuth:Issuer"),

            ValidateAudience = true,
            ValidAudience = _configuration.GetValue<string>("InnoShopAuth:Audience"),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var purposeClaim = principal.FindFirst("purpose")?.Value;
            if (purposeClaim != "password_recovery")
            {
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }
}
