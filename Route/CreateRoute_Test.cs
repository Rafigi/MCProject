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

    public class CreateRoute_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void Create_Route_Factory(
            [Frozen] IRouteFactory routeFactory,
            Route route)
        {
            //Information
            var _route = routeFactory.Create(route);

            //Act
            A.CallTo(() => routeFactory.Create(A<Route>.Ignored)).Returns(route);

            //Test
            Assert.AreNotEqual(_route.RouteID, route.RouteID);
        }


        [Test]
        [AutoCreateTestInput]
        public void Send_Route_With_ServiceBus(
        [Frozen] IRouteFactory routeFactory,
        [Frozen] IServiceBus serviceBus,
        RouteController routeController,
        Route route
            )
        {
            //Information
            A.CallTo(() => routeFactory.Create(A<Route>.Ignored)).Returns(route);

            //Act
            routeController.Create(route);

            //Test
            A.CallTo(() => serviceBus.Add(A<CreateRouteCommand>.Ignored))
                .MustHaveHappened();
        }

    }
}