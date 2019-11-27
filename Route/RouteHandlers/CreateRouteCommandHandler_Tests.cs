namespace MCRoute.Test.UserHandlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Route.Commands;
    using McWorld.Route.Handlers;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using McWorld.User.Commands;
    using McWorld.User.Handler;
    using NUnit.Framework;

    public class CreateRouteCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateRoute_CallRouteFactory(
            [Frozen] IRouteFactory routeFactory,
            CreateRouteCommand message,
            Route route,
            CreateRouteCommandHandler createRouteCommandHandler)
        {
            //Information
            A.CallTo(() => routeFactory.Create(message.Route)).Returns(route);

            //Act
            createRouteCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => routeFactory.Create(message.Route)).MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateRoute_AddWithIRouteRepository(
            [Frozen] IRouteRepository routeRepository,
            [Frozen] IRouteFactory routeFactory,
            CreateRouteCommand message,
            Route route,
            CreateRouteCommandHandler createRouteCommandHandler)
        {
            //Information
            A.CallTo(() => routeFactory.Create(message.Route)).Returns(route);

            //Act
            createRouteCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => routeRepository.Add(route)).MustHaveHappened();
        }
    }
}