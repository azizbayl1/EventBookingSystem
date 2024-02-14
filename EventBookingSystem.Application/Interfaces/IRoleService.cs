using EventBookingSystem.Application.DTOs.Role.Request;
using EventBookingSystem.Application.DTOs.Role.Response;

namespace EventBookingSystem.Application.Interfaces;

public interface IRoleService
{
    List<RoleResponseDTO> GetRoles();
    RoleResponseDTO GetRoleById(int roleId);
    void CreateRole(RoleRequestDTO roleRequestDTO);
    bool UpdateRole(RoleRequestDTO roleRequestDTO);
    bool DeleteRole(int roleId);

        
}
