using AutoMapper;
using EventBookingSystem.Application.DTOs.EventSeat.Response;
using EventBookingSystem.Application.DTOs.Participant.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventBookingSystem.Application.Services;

public class EventSeatService : IEventSeatService
{
    private readonly IEventSeatRepository _eventSeatRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IParticipantRepository _participantRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public EventSeatService(
        IEventSeatRepository eventSeatRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IParticipantRepository participantRepository,
        IUserRepository userRepository)
    {
        _eventSeatRepository = eventSeatRepository;
        _httpContextAccessor = httpContextAccessor;
        _participantRepository = participantRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public List<EventSeatResponseDTO> GetSeats()
    {
        return _mapper.Map<List<EventSeatResponseDTO>>(_eventSeatRepository.GetAll());
    }
    public List<EventSeatResponseDTO> GetSeatsByEventId(int eventId)
    {
        var seats = _eventSeatRepository.Find(s=> s.EventId == eventId).OrderBy(s=> s.Id);
        return _mapper.Map<List<EventSeatResponseDTO>>(seats);
    }
    public bool BookSeat(int seatId)
    {
        var user = GetCurrentUser();
        var seat = _eventSeatRepository.GetById(seatId);

        if(seat.IsAvailable != false)
        {
            var participant = new Participant()
            {
                FullName = String.Concat(user.FirstName, " ", user.LastName),
                Email = user.Email,
                UserId = user.Id,
                EventId = seat.EventId,
            };
            _participantRepository.Add(participant);

            seat.ParticipantId = participant.Id;
            seat.IsAvailable = false;
            _eventSeatRepository.Update(seat);
            return true;
        }
        return false;
    }
    public bool CancelBooking(int seatId) 
    {
        var seat = _eventSeatRepository.GetById(seatId);
        if (seat.IsAvailable != true)
        {
            seat.ParticipantId = null;
            seat.IsAvailable = true;
            _eventSeatRepository.Update(seat);

            if (seat.ParticipantId != null)
            {
                var participant = _participantRepository.GetById((int)seat.ParticipantId);
                _participantRepository.Remove(participant);
            }

            return true;
        }
        return false;
    }
    public int GetCurrentUserId()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Convert.ToInt32(userId);
    }
    public User GetCurrentUser()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return _userRepository.GetById(Convert.ToInt32(userId));
    }

    public List<ParticipantResponseDTO> GetMyBookings()
    {
        var userId = GetCurrentUserId();
        return _mapper.Map<List<ParticipantResponseDTO>>(_participantRepository
            .Find(p => p.UserId == userId).ToList());
    }
}
