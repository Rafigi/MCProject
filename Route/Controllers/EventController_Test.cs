namespace MCRoute.Test.Controllers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Event.Commands;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Factory;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using McWorld.Shared.Queryables;
    using McWorld.Web.Controllers;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class EventController_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_GetAll(
            [Frozen] IEventQueryables eventQueryables,
            EventController eventController,
            IEnumerable<EventDto> @event)
        {
            //Information
            A.CallTo(() => eventQueryables.GetAll()).Returns(@event);

            //Act
            eventController.GetAll();

            //Test
            A.CallTo(() => eventQueryables.GetAll())
                .MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void EventController_GetAllUserCreatedEvents(
            [Frozen] IEventQueryables eventQueryables,
            EventController eventController,
            Guid userId,
            IEnumerable<EventDto> @event)
        {
            //Information
            A.CallTo(() => eventQueryables.GetByUser(userId)).Returns(@event);

            //Act
            eventController.GetAllUserCreatedEvents(userId);

            //Test
            A.CallTo(() => eventQueryables.GetByUser(userId))
                .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_GetById(
            [Frozen] IEventQueryables eventQueryables,
            EventController eventController,
            Guid userId,
            EventDto @event)
        {
            @event.EventID = userId;
            //Information
            A.CallTo(() => eventQueryables.GetById(userId)).Returns(@event);

            //Act
            eventController.GetById(userId);

            //Test
            A.CallTo(() => eventQueryables.GetById(userId))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_GetUserRegistrated(
            [Frozen] IEventQueryables eventQueryables,
            EventController eventController,
            Guid userId,
            IEnumerable<EventDto> @event)
        {
            //Information
            A.CallTo(() => eventQueryables.GetUsersRegistered(userId)).Returns(@event);

            //Act
            eventController.GetUserRegistrated(userId);

            //Test
            A.CallTo(() => eventQueryables.GetUsersRegistered(userId))
                .MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void EventController_Create_createEventCommandHandler(
            [Frozen] ICommandHandler<CreateEventCommand> createEventCommandHandler,
            [Frozen] IEventFactory eventFactory,
            Event @event,
            EventController eventController)
        {
            //Information
            //A.CallTo(() => eventFactory.Create(A<Event>.Ignored)).Returns(@event);

            //Act
            eventController.Create(@event);

            //Test
            A.CallTo(() => createEventCommandHandler.ExecuteAsync(A<CreateEventCommand>.Ignored))
                .MustHaveHappened();

        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_Create_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            Event @event,
            EventController eventController)
        {
            //Information

            //Act
            eventController.Create(@event);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_Update_createEventCommandHandler(
            [Frozen] ICommandHandler<UpdateEventCommand> updateEventCommandHandler,
            Event @event,
            EventController eventController)
        {
            //Information

            //Act
            eventController.Update(@event);

            //Test
            A.CallTo(() => updateEventCommandHandler
            .ExecuteAsync(A<UpdateEventCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_update_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            Event @event,
            EventController eventController)
        {
            //Information

            //Act
            eventController.Update(@event);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void EventController_RegisterUser_registerUserOnEventCommand(
            [Frozen] ICommandHandler<RegisterUserOnEventCommand> registerUserOnEventCommand,
            EventController eventController)
        {
            //Information
            var registration = new Registration(Guid.NewGuid(), Guid.NewGuid());

            //Act
            eventController.RegisterUser(registration);

            //Test
            A.CallTo(() => registerUserOnEventCommand
            .ExecuteAsync(A<RegisterUserOnEventCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_RegisterUser_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            EventController eventController,
            Registration registration,
            Event @event)
        {
            //Information

            //Act
            eventController.RegisterUser(registration);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_UnRegisterUser_unregisterUserOnEventCommand(
        [Frozen] ICommandHandler<UnRegisterUserOnEventCommand> unregisterUserOnEventCommand,
        EventController eventController)
        {
            //Information
            var registration = new Registration(Guid.NewGuid(), Guid.NewGuid());

            //Act
            eventController.UnRegisterUser(registration);

            //Test
            A.CallTo(() => unregisterUserOnEventCommand
            .ExecuteAsync(A<UnRegisterUserOnEventCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_UnRegisterUser_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            EventController eventController,
            Registration registration,
            Event @event)
        {
            //Information

            //Act
            eventController.UnRegisterUser(registration);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_Delete_deleteEventCommandHandler(
            [Frozen] ICommandHandler<DeleteEventCommand> deleteEventCommandHandler,
            EventController eventController,
            Event @event)
        {
            //Information

            //Act
            eventController.Delete(@event.EventID);

            //Test
            A.CallTo(() => deleteEventCommandHandler
            .ExecuteAsync(A<DeleteEventCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void EventController_Delete_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            EventController eventController,
            Event @event)
        {
            //Information

            //Act
            eventController.Delete(@event.EventID);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

    }
}