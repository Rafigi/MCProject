namespace MCRoute.Test.Handlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Event;
    using McWorld.Event.Commands;
    using McWorld.Route;
    using McWorld.Route.Commands;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using NUnit.Framework;

    public class CreateEventCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateEvent_CallEventFactory(
            [Frozen] IEventFactory eventFactory,
            CreateEventCommand message,
            Event @event,
            CreateEventCommandHandler createEventCommandHandler)
        {
            //Information
            A.CallTo(() => eventFactory.Create(message.Event)).Returns(@event);

            //Act
            createEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventFactory.Create(message.Event)).MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateEvent_AddWithIEventRepository(
            [Frozen] IEventRepository eventRepository,
            [Frozen] IEventFactory eventFactory,
            CreateEventCommand message,
            Event @event,
            CreateEventCommandHandler createEventCommandHandler)
        {
            //Information
            A.CallTo(() => eventFactory.Create(message.Event)).Returns(@event);

            //Act
            createEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => eventRepository.Add(@event)).MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateEvent_SendICommandHandlerWithCreateRouteCommand(
            [Frozen] ICommandHandler<CreateRouteCommand> createRouteCommandHandler,
            [Frozen] IEventRepository eventRepository,
            [Frozen] IEventFactory eventFactory,
            CreateEventCommand message,
            Event @event,
             CreateEventCommandHandler createEventCommandHandler)
        {
            //Information
            A.CallTo(() => eventFactory.Create(message.Event)).Returns(@event);
            A.CallTo(() => eventRepository.Add(@event));

            //Act
            createEventCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => createRouteCommandHandler.ExecuteAsync(A<CreateRouteCommand>.Ignored))
                .MustHaveHappened();
        }



    }
}