namespace Tests.MCRoute.Test
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Event;
    using McWorld.Shared.Factory;
    using McWorld.Shared.Models;
    using McWorld.Shared.ServicesBus;
    using McWorld.Web.Controllers;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class CreateEvent_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void Create_Event_Factory(Event @event)
        {
            EventFactory eventFactory = new EventFactory();
            var _event = eventFactory.Create(@event);
            Assert.AreNotEqual(@event.EventID, _event.EventID);
        }

        [Test]
        [AutoCreateTestInput]
        public void Create_Event_With_Factory_Route_Added()
        {
            Event @event = new Event();
            @event.Route = new Route();
            @event.Route.Addresses = new List<Address>();
            @event.Route.Addresses.Add(new Address());
            @event.Route.Addresses.Add(new Address());

            EventFactory eventFactory = new EventFactory();
            var _event = eventFactory.Create(@event);
            Assert.AreNotEqual(_event.Route.RouteID, @event.Route.RouteID, "ID Is Added");
        }

        //[Test]
        //[AutoCreateTestInput]
        //public void Send_Event_With_ServiceBus(
        //    [Frozen] IServiceBus serviceBus,
        //    EventController eventController,
        //    Event @event)
        //{

        //    eventController.Create(@event);

        //    A.CallTo(() => serviceBus.Add(new CreateEventCommand(@event))).MustHaveHappened();
        //}

    }
}