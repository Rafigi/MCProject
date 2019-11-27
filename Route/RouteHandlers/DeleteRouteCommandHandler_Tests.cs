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

    public class DeleteRouteCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        [AutoCreateTestInput]
        public void DeleteRoute_CallIRouteRepositoryRemove(
            [Frozen] IRouteRepository routeRepository,
            [Frozen] IRouteFactory routeFactory,
            DeleteRouteCommand message,
            Route route,
            DeleteRouteCommandHandler deleteRouteCommandHandler)
        {
            //Information
            A.CallTo(() => routeRepository.GetById(message.RouteId)).Returns(route);

            //Act
            deleteRouteCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => routeRepository.Remove(route)).MustHaveHappened();
        }
    }
}