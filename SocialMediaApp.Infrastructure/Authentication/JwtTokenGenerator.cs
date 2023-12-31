﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Application.Persistence.Contracts.Common;
using SocialMediaApp.Application.Persistence.Contracts.Common.Services;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Infrastructure.Authentication
{
    public  class JwtTokenGenerator : IJwtTokenGenerator
    {

        private readonly JwtSettings _jwtSettings;

        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256Signature);

               
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id.ToString())

            
            };


            var securityToken = new JwtSecurityToken(
                            issuer: _jwtSettings.Issuer,
                            audience: _jwtSettings.Audience,
                            claims: claims,
                            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                            signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
    
}
