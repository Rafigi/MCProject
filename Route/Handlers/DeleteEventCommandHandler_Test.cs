namespace MCRoute.Test.Handlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Event.Commands;
    using McWorld.Event.Handlers;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using NUnit.Framework;
    using System;

    public class DeleteEventCommandHandler_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void DeleteEvent_UserDoesNotExist(
            [Frozen] IEventRepository eventRepository,
            Event @event,
            DeleteEventCommand message,
            DeleteEventCommandHandler deleteEventCommandHandler)
        {
            //Information

            //Act
            deleteEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.GetById(message.EventId)).Throws(new ArgumentNullException());
            A.CallTo(() => eventRepository.Remove(@event))
                .MustNotHaveHappened();

        }

        [Test]
        [AutoCreateTestInput]
        public void DeleteEvent_UserExist(
            [Frozen] IEventRepository eventRepository,
            Event @event,
            DeleteEventCommand message,
            DeleteEventCommandHandler deleteEventCommandHandler)
        {
            //Information
            A.CallTo(() => eventRepository.GetById(message.EventId)).Returns(@event);

            //Act
            deleteEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.Remove(@event))
                .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void DeleteEvent_EventIsRemoved(
            [Frozen] IEventRepository eventRepository,
            Event @event,
            DeleteEventCommand message,
            DeleteEventCommandHandler deleteEventCommandHandler)
        {
            //Information
            @event.EventID = message.EventId;
            eventRepository.Add(@event);
            var actual = eventRepository.GetById(message.EventId);

            //Act
            deleteEventCommandHandler.ExecuteAsync(message);

            //Test
            var expected = eventRepository.GetById(@event.EventID);
            Assert.AreNotEqual(expected, actual);

        }

    }
}
