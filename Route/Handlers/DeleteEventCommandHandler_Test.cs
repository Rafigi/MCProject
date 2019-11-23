namespace MCRoute.Test.Handlers
{
    using AutoFixture.NUnit3;
    using global::MCRoute.Test;
    using FakeItEasy;
    using McWorld.Event;
    using McWorld.Event.Commands;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using NUnit.Framework;
    using McWorld.Event.Handlers;
    using System;

    public class DeleteEventCommandHandler_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void DeleteEvent_GetEventWithRepostory_ReturnNull(
            [Frozen] IEventRepository  eventRepository,
            Event @event,
            DeleteEventCommand message,
            DeleteEventCommandHandler deleteEventCommandHandler)
        {
            //Information
            eventRepository.Add(@event);
            A.CallTo(() => eventRepository.GetById(@event.EventID)).Returns(null);

            //Act
            deleteEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.GetById(@event.EventID)).Throws<ArgumentNullException>();
        }

        [Test]
        [AutoCreateTestInput]
        public void DeleteEvent_GetEventById_returnNotNull(
            [Frozen] IEventRepository eventRepository,
            Event @event,
            Guid eventId,
            DeleteEventCommand message,
            DeleteEventCommandHandler deleteEventCommandHandler)
        {
            //Information
            A.CallTo(() => eventRepository.GetById(A<Guid>.Ignored)).Returns(@event);

            //Act
            deleteEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.GetById(A<Guid>.Ignored)).MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateEvent_EventRemovedCalled(
            [Frozen] IEventRepository eventRepository,
            DeleteEventCommand message,
            Event @event,
             DeleteEventCommandHandler deleteEventCommandHandler)
        {
            //Information
            A.CallTo(() => eventRepository.GetById(A<Guid>.Ignored)).Returns(@event);

            //Act
            deleteEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.Remove(@event)).MustHaveHappened();
        }


    }
}
