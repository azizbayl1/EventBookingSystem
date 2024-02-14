using AutoMapper;
using EventBookingSystem.Application.DTOs.Participant.Response;
using EventBookingSystem.Application.DTOs.Role.Request;
using EventBookingSystem.Application.DTOs.User.Request;
using EventBookingSystem.Application.DTOs.User.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventBookingSystem.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IParticipantRepository _participantRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public UserService(
        IUserRepository userRepository, 
        IMapper mapper,
        IParticipantRepository participantRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _participantRepository = participantRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public List<UserResponseDTO> GetUsers()
    {
        var users = _userRepository.GetAll().ToList();
        return _mapper.Map<List<UserResponseDTO>>(users);
        
    }

    public UserResponseDTO GetUserById(int id)
    {
        var user = _userRepository.GetById(id);
        return _mapper.Map<UserResponseDTO>(user);
    }

    public bool UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        var user = _userRepository.GetById(userUpdateDTO.Id);
        if(user != null)
        {
            var mapped = _mapper.Map<User>(userUpdateDTO);
            _userRepository.Update(mapped);
            return true;
        }
        return false;
    }

    public bool DeleteUser(int userId)
    {
        var user = _userRepository.GetById(userId);
        if (user!=null)
        {
            _userRepository.Remove(user);
            return true;
        }
        return false;
    }

    public void CreateUser(UserCreateDTO userCreateDTO)
    {
        var user = _mapper.Map<User>(userCreateDTO);
        _userRepository.Add(user);
    }

    public List<ParticipantResponseDTO> GetMyBookings()
    {
        var currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        return _mapper.Map<List<ParticipantResponseDTO>>(_participantRepository.Find(p => p.UserId == currentUserId));
    }

    public void AddRole(UserRoleDTO userRoleDTO)
    {
        var user = _userRepository.GetById(userRoleDTO.UserId);
        user.RoleId = userRoleDTO.RoleId;
        _userRepository.Update(user);
    }
}
