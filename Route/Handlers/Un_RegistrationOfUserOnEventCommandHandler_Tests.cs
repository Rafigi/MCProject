using AutoFixture.NUnit3;
using FakeItEasy;
using McWorld.Event.Commands;
using McWorld.Event.Handlers;
using McWorld.Shared.IRepository;
using McWorld.Shared.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCRoute.Test.Handlers
{
    class Un_RegistrationOfUserOnEventCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void RegisterUserOnEvent_(
            [Frozen] IEventRepository eventRepository,
            RegisterUserOnEventCommand message,
            Un_RegistrationOfUserOnEventCommandHandler un_RegistrationOfUserOnEventCommandHandler)
        {
            //Information

            //Act
            un_RegistrationOfUserOnEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.RegisterUser(A<Guid>.Ignored, A<Guid>.Ignored))
                .MustNotHaveHappened();

        }

        [Test]
        [AutoCreateTestInput]
        public void RegisterUserOnEvent_UserIsUnRegistered(
            [Frozen] IEventRepository eventRepository,
            Event @event,
            ICollection<Registration> registration,
            UnRegisterUserOnEventCommand message,
            Un_RegistrationOfUserOnEventCommandHandler un_RegistrationOfUserOnEventCommandHandler)
        {
            //Information

            //Act
            un_RegistrationOfUserOnEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.UnRegisterUser(A<Guid>.Ignored, A<Guid>.Ignored))
                .MustNotHaveHappened();

        }
    }
}
