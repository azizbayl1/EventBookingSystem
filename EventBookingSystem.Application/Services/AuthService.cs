using AutoMapper;
using EventBookingSystem.Application.DTOs.Authentication.Request;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace EventBookingSystem.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;


    public AuthService(IUserRepository userRepository, IConfiguration config, IMapper mapper)
    {
        _userRepository = userRepository;
        _config = config;
        _mapper = mapper;
    }

    public User Authenticate(LoginDTO login)
    {
        //var currentUser = _dbContext.Users.FirstOrDefault(o => o.Name.ToLower() == userLogin.Name.ToLower() && o.Password == userLogin.Password);
        var currentUser = _userRepository.GetAll().Where(o => o.Email.ToLower() == login.Email.ToLower() && o.Password == login.Password).FirstOrDefault();
        if (currentUser != null)
        {
            return currentUser;
        }

        return null;
    }

    public string Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.Name )
        };

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
          _config["Jwt:Audience"],
          claims,
          expires: DateTime.Now.AddMinutes(15),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string Login(LoginDTO login)
    {
        var user = Authenticate(login);
        if (user != null)
        {
            var token = Generate(user);
            return token;
        }
        return null;
    }

    public string Registration(RegistrationDTO registrationDTO)
    {

        string emailPattern = @"^[a-zA-Z0-9._%+-]+@asoiu\.edu\.az$";
        string passwordPattern = "^(?=.*[!@#$%^&*(),.?\":{}|<>])[a-zA-Z0-9!@#$%^&*(),.?\":{}|<>]{6,}$";


        if (!Regex.IsMatch(registrationDTO.Email, emailPattern))
        {
            return "Email is not in a valid format";
        }

        if (_userRepository.GetAll().Any(u => u.Email == registrationDTO.Email))
        {
            return "A user with this email already exists";
        }

        if (!Regex.IsMatch(registrationDTO.Password, passwordPattern))
        {
            return "Password must be at least 6 characters long, contain at least one special character.";
        }

        if (registrationDTO.Password != registrationDTO.ConfirmPassword)
        {
            return "Password and confirm password do not match";
        }

        // Map RegistrationDto to User entity
        var newUser = _mapper.Map<User>(registrationDTO);

        // Add and save new user to repository
        _userRepository.Add(newUser);
        return "User registered successfully";
    }
}
