using EventBookingSystem.Application.DTOs.Role.Request;
using EventBookingSystem.Application.DTOs.User.Request;
using EventBookingSystem.Application.DTOs.User.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface IUserService
{
    List<UserResponseDTO> GetUsers();
    UserResponseDTO GetUserById(int id);
    void CreateUser(UserCreateDTO userCreateDTO);
    bool UpdateUser(UserUpdateDTO userUpdateDto);
    bool DeleteUser(int userId);
    void AddRole(UserRoleDTO userRoleDTO);
}
