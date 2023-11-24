using EventCalendarApp.Exceptions;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using EventCalendarApp.Repositories;
using EventCalendarApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCalendarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ILogger<EventController> _logger;

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Get(string userId)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.GetEvents(userId);
                _logger.LogInformation("Event listed");
                return Ok(result);
            }
            catch (NoEventsAvailableException e)
            {
                errorMessage = e.Message;
                _logger.LogError(errorMessage);
            }
            return BadRequest(errorMessage);
        }
        //[Authorize(Roles = "organizer")]
        [HttpPost]
        public ActionResult Create(Event events)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.Add(events);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpPut]
        public ActionResult Update(Event events)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.Update(events);
                return Ok(events);
            }
            catch (EventsCantUpdateException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

        [HttpDelete]
        public ActionResult Remove(Event events)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _eventService.Remove(events);
                return Ok(events);
            }
            catch (EventsCantRemoveException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}