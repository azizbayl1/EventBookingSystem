using EventBookingSystem.Application.DTOs.Authentication.Request;
using EventBookingSystem.Domain.Entities;

namespace EventBookingSystem.Application.Interfaces;

public interface IAuthService
{
    User Authenticate(LoginDTO login);
    string Generate(User user);
    string Registration(RegistrationDTO registrationDTO);
    string Login(LoginDTO login);
}
