using AutoMapper;
using EventBookingSystem.Application.DTOs.Role.Request;
using EventBookingSystem.Application.DTOs.Role.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(
        IRoleRepository roleRepository,
        IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public List<RoleResponseDTO> GetRoles()
    {
        return _mapper.Map<List<RoleResponseDTO>>(_roleRepository.GetAll());
    }

    public RoleResponseDTO GetRoleById(int roleId)
    {
        var role = _roleRepository.GetById(roleId);
        return _mapper.Map<RoleResponseDTO>(role);
    }

    public void CreateRole(RoleRequestDTO roleRequestDTO)
    {
        var role = _mapper.Map<Role>(roleRequestDTO);
        _roleRepository.Add(role);
    }

    public bool DeleteRole(int roleId)
    {
        var role = _roleRepository.GetById(roleId);
        if (role != null)
        {
            _roleRepository.Remove(role);
            return true;
        }
        return false;
    }

    public bool UpdateRole(RoleRequestDTO roleRequestDTO)
    {
        var role = _roleRepository.GetById(roleRequestDTO.Id);
        if (role != null)
        {
            var mapped = _mapper.Map<Role>(roleRequestDTO);
            _roleRepository.Update(mapped);
            return true;
        }
        return false;
    }


}
