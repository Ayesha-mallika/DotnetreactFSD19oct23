using EventCalendarApp.Contexts;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using EventCalendarApp.Models.DTOs;
using EventCalendarApp.Repositories;
using EventCalendarApp.Services;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace ECalendarTest
{
    public class EventServiceTest
    {
        IRepository<int, Event> eventRepository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<CalendarContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            CalendarContext context = new CalendarContext(dbOptions);
            eventRepository = new EventRepository(context);
        }

        [Test]
        public void AddEventTest()
        {
            //Arrange
            IEventService eventService = new EventService(eventRepository);
            DateTime dateTime = DateTime.Now;
            var events = new Event
            {
                title = "hexaware training",
                Description = "Attend the DotNet Training",
                StartDateTime = dateTime.ToString(),
                EndDateTime = dateTime.ToString(),
                NotificationDateTime = "2023 - 12 - 20T15:56",
                Location = "near bhvrm",
                IsRecurring = true,
                Recurring_frequency = "monthly",
                ShareEventWith = "xyz@gmail.com",
                Access = "public",
                Category = "work",
                Email = "ayeshajasmeen79@gmail.com"
               
            };
            //Action
            var result = eventService.Add(events);
            //Assert
            Assert.IsNotNull(result);

        }
        [Test]
        public void GetEventsTest()
        {
            //Arrange

            IEventService eventService = new EventService(eventRepository);
            string userId = "ayeshajasmeen79@gmail.com";

            //Action
            var result = eventService.GetEvents(userId);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPublicEventsTest()
        {
            //Arrange
            IEventService eventService = new EventService(eventRepository);
            string userId = "ayeshajasmeen79@gmail.com";

            //Action
            var result = eventService.GetPublicEvents(userId);

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void RemoveTest()
        {
            //Arrange
            IEventService eventService = new EventService(eventRepository);
            int id = 1;

            //Act
            var result = eventService.Remove(id);

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void UpdateTest()
        {
            //Arrange
            IEventService eventService = new EventService(eventRepository);
            DateTime dateTime = DateTime.Now;
            var events = new Event
            {
                title = "hexaware training",
                Description = "Attend the DotNet Training",
                StartDateTime = dateTime.ToString(),
                EndDateTime = dateTime.ToString(),
                NotificationDateTime = "2023 - 12 - 20T15:56",
                Location = "near bhvrm",
                IsRecurring = true,
                Recurring_frequency = "monthly",
                ShareEventWith = "xyz@gmail.com",
                Access = "public",
                Category = "work",
                Email = "ayeshajasmeen79@gmail.com"

            };
            //Action
            var result = eventService.Add(events);
            var update = new Event
            {
                Id=1,
                title = "hexaware training",
                Description = "Attend the DotNet Training",
                StartDateTime = dateTime.ToString(),
                EndDateTime = dateTime.ToString(),
                NotificationDateTime = "2023 - 12 - 20T15:56",
                Location = "near bhvrm",
                IsRecurring = true,
                Recurring_frequency = "monthly",
                ShareEventWith = "xyz@gmail.com",
                Access = "public",
                Category = "work",
                Email = "ayeshajasmeen79@gmail.com"
            };

            //Act
            var result2 = eventService.Update(events);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}