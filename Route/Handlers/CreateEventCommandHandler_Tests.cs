namespace Tests.MCRoute.Test
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Shared.Factory;
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
        public void Create_Event_Factory(
            [Frozen] IEventFactory eventFactory,
            Event @event)
        {
            //Information
            var _event = eventFactory.Create(@event);

            //Act
            A.CallTo(() => eventFactory.Create(A<Event>.Ignored)).Returns(@event);

            //Test
            Assert.AreNotEqual(@event.EventID, _event.EventID);
        }

        //[Test]
        //[AutoCreateTestInput]
        //public void Send_Event_With_ServiceBus(
        //    [Frozen] IEventFactory eventFactory,
        //    [Frozen] ICommandHandler<CreateEventCommand> commandHandler,
        //    EventController eventController,
        //    Event @event)
        //{

        //    A.CallTo(() => eventFactory.Create(A<Event>.Ignored)).Returns(@event);
        //    //Act
        //    eventController.Create(@event);

        //    //Test
        //    A.CallTo(() => commandHandler.ExecuteAsync(A<CreateEventCommand>.Ignored)).MustHaveHappened();
        //}

    }
}