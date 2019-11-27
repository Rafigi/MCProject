namespace MCRoute.Test.UserHandlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Route.Commands;
    using McWorld.Route.Handlers;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using McWorld.Shared.Queryables;
    using NUnit.Framework;
    using System;

    public class UpdateRouteCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        [AutoCreateTestInput]
        public void UpdateRoute_CallIRouteRepositoryUpdate(
            [Frozen] IRouteRepository routeRepository,
            [Frozen] IRouteQueryables routeQueryables,
            UpdateRouteCommand message,
            RouteDto routeDto,
            Route route,
            UpdateRouteCommandHandler updateRouteCommandHandler)
        {
            //Information
            A.CallTo(() => routeQueryables.GetById(message.Route.RouteID)).Returns(routeDto);

            //Act
            updateRouteCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => routeRepository.Update(message.Route)).MustHaveHappened();
        }


        [Test]
        [AutoCreateTestInput]
        public void UpdateRoute_NoUserWithThatIdExist(
            [Frozen] IRouteRepository routeRepository,
            [Frozen] IRouteQueryables routeQueryables,
            UpdateRouteCommand message,
            RouteDto routeDto,
            Route route,
            UpdateRouteCommandHandler updateRouteCommandHandler)
        {
            //Information
            A.CallTo(() => routeQueryables.GetById(message.Route.RouteID)).Returns(null);

            try
            {
                //Act
                updateRouteCommandHandler.ExecuteAsync(message);

            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual($"Value cannot be null.", e.Message);
            }
        }
    }
}