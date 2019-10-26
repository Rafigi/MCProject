namespace Tests.MCRoute.Test
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Event;
    using McWorld.Route;
    using McWorld.Shared.Factory;
    using McWorld.Shared.Models;
    using McWorld.Shared.ServicesBus;
    using McWorld.Web.Controllers;
    using NUnit.Framework;

    public class CreateEvent_Test
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

        [Test]
        [AutoCreateTestInput]
        public void Send_Event_With_ServiceBus(
            [Frozen] IEventFactory eventFactory,
            [Frozen] IServiceBus serviceBus,
            EventController eventController,
            Event @event)
        {
            //Information
            A.CallTo(() => eventFactory.Create(A<Event>.Ignored)).Returns(@event);

            //Act
            eventController.Create(@event);

            //Test
            A.CallTo(() => serviceBus.Add(A<CreateEventCommand>.Ignored))
                .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void Send_Route_With_ServiceBus(
        [Frozen] IEventFactory eventFactory,
        [Frozen] IServiceBus serviceBus,
        EventController eventController,
        Event @event
            )
        {
            //Information
            A.CallTo(() => eventFactory.Create(A<Event>.Ignored)).Returns(@event);

            //Act
            eventController.Create(@event);

            //Test
            A.CallTo(() => serviceBus.Add(A<CreateRouteCommand>.Ignored))
                .MustHaveHappened();
        }

    }
}