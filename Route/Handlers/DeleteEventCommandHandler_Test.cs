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
    using McWorld.Shared.Queryables;
    using McWorld.Shared.Dtos;

    public class DeleteEventCommandHandler_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //[AutoCreateTestInput]
        //public void DeleteEvent_UserIsNull(
        //    [Frozen] IEventRepository  eventRepository,
        //    Event @event,
        //    DeleteEventCommand message,
        //    DeleteEventCommandHandler deleteEventCommandHandler)
        //{
        //    //Information
        //    A.CallTo(() => eventRepository.GetById(message.EventId)).Returns(@event);

        //    //Act
        //    deleteEventCommandHandler.ExecuteAsync(message);

        //    //Test

        //}

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

        //[Test]
        //[AutoCreateTestInput]
        //public void DeleteEvent_EventIsRemoved(
        //    [Frozen] IEventRepository eventRepository,
        //    Event @event,
        //    DeleteEventCommand message,
        //    DeleteEventCommandHandler deleteEventCommandHandler)
        //{
        //    //Information
        //    eventRepository.Add(@event);
        //    A.CallTo(() => eventRepository.GetById(message.EventId)).Returns(@event);

        //    //Act
        //    deleteEventCommandHandler.ExecuteAsync(message);

        //    //Test
        //    var e = eventRepository.GetById(@event.EventID);
        //}





    }
}
