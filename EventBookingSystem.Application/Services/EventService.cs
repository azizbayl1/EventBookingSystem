using AutoMapper;
using EventBookingSystem.Application.DTOs.Event.Request;
using EventBookingSystem.Application.DTOs.Event.Response;
using EventBookingSystem.Application.Interfaces;
using EventBookingSystem.Domain.Entities;
using EventBookingSystem.Domain.Repositories.EntityRepositories;

namespace EventBookingSystem.Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IVenueRepository _venueRepository;
    private readonly IEventSeatRepository _eventSeatRepository;
    private readonly IMapper _mapper;

    public EventService( 
        IEventRepository eventRepository,
        IVenueRepository venueRepository,
        IEventSeatRepository eventSeatRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository;
        _venueRepository = venueRepository;
        _eventSeatRepository = eventSeatRepository;
        _mapper = mapper;
    }
    public void CreateEvent(EventCreateDTO eventCreate)
    {
        var mapped = _mapper.Map<Event>(eventCreate);
        _eventRepository.Add(mapped);


        var venue = _venueRepository.GetById(eventCreate.VenueId);

        //GenerateEventSeats
        var totalSeats = venue.Capacity;
        var rows = totalSeats / venue.RowCapacity;
        for (var row = 1; row <= rows; row++)
        {
            var seatNumber = 1;
            for (var seatInRow = 1; seatInRow <= venue.RowCapacity; seatInRow++)
            {
                var eventSeat = new EventSeat
                {
                    EventId = mapped.Id,
                    Row = row,
                    SeatNumber = seatNumber,
                    IsAvailable = true
                };
                _eventSeatRepository.Add(eventSeat);
                seatNumber++;
            }
        }
    }

    public List<EventResponseDTO> GetEvents()
    {
        var events = _eventRepository.GetAll();
        return _mapper.Map<List<EventResponseDTO>>(events);
    }

    public EventResponseDTO GetEventById(int eventId)
    {
        var @event = _eventRepository.GetById(eventId);
        return _mapper.Map<EventResponseDTO>(@event);
    }

    public bool DeleteEvent(int eventId)
    {
        var @event = _eventRepository.GetById(eventId);
        if (@event != null)
        {
            _eventRepository.Remove(@event);
            _eventSeatRepository.RemoveRange(_eventSeatRepository.Find(s => s.EventId == eventId).ToList());
            return true;
        }
        return false;
    }

    public bool UpdateEvent(EventUpdateDTO eventUpdate)
    {
        var @event = _eventRepository.GetById(eventUpdate.Id);
        if (@event != null)
        {
            var mapped = _mapper.Map<Event>(eventUpdate);
            _eventRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
