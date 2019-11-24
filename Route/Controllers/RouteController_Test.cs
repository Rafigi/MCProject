namespace MCRoute.Test.Controllers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Event.Commands;
    using McWorld.Route;
    using McWorld.Route.Commands;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using McWorld.Shared.Queryables;
    using McWorld.Web.Controllers;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class RouteController_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void RouteController_GetAll(
            [Frozen] IRouteQueryables routeQueryables,
            RouteController routeController,
            IEnumerable<RouteDto> routes)
        {
            //Information
            A.CallTo(() => routeQueryables.GetAll()).Returns(routes);

            //Act
            routeController.GetAll();

            //Test
            A.CallTo(() => routeQueryables.GetAll()).MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void RouteController_GetAllUserCreatedRoutes(
         [Frozen] IRouteQueryables routeQueryables,
            RouteController routeController,
            Guid userId,
            IEnumerable<RouteDto> routes)
        {
            //Information
            A.CallTo(() => routeQueryables.GetByUser(userId)).Returns(routes);

            //Act
            routeController.GetAllUserCreatedRoutes(userId);

            //Test
            A.CallTo(() => routeQueryables.GetByUser(userId)).MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void RouteController_GetById(
            [Frozen] IRouteQueryables routeQueryables,
            RouteController routeController,
            Guid userId,
            RouteDto routeDto)
        {
            //Information
            A.CallTo(() => routeQueryables.GetById(userId)).Returns(routeDto);

            //Act
            routeController.GetById(userId);

            //Test
            A.CallTo(() => routeQueryables.GetById(userId))
                .MustHaveHappened();
        }


        [Test]
        [AutoCreateTestInput]
        public void RouteController_Create_createRouteCommandHandler(
            [Frozen] ICommandHandler<CreateRouteCommand> createRouteCommandHandler,
            Route route,
            RouteController routeController)
        {
            //Information

            //Act
            routeController.Create(route);

            //Test
            A.CallTo(() => createRouteCommandHandler
            .ExecuteAsync(A<CreateRouteCommand>.Ignored))
                .MustHaveHappened(); ;
        
        }

        [Test]
        [AutoCreateTestInput]
        public void RouteController_Create_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            Route route,
            RouteController routeController)
        {
            //Information

            //Act
            routeController.Create(route);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void RouteController_Update_UpdateRouteCommandHandler(
            [Frozen] ICommandHandler<UpdateRouteCommand> updateRouteCommandHandler,
            Route route,
            RouteController routeController)
        {
            //Information

            //Act
            routeController.Update(route);

            //Test
            A.CallTo(() => updateRouteCommandHandler
            .ExecuteAsync(A<UpdateRouteCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void RouteController_update_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            Route route,
            RouteController routeController)
        {
            //Information

            //Act
            routeController.Update(route);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void RouteController_Delete_deleteRouteCommandHandler(
            [Frozen] ICommandHandler<DeleteRouteCommand> deleteRouteCommandHandler,
            RouteController routeController,
            Route route)
        {
            //Information

            //Act
            routeController.Delete(route.RouteID);

            //Test
            A.CallTo(() => deleteRouteCommandHandler
            .ExecuteAsync(A<DeleteRouteCommand>.Ignored))
            .MustHaveHappened(); ;
        }

        [Test]
        [AutoCreateTestInput]
        public void RouteController_Delete_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            RouteController routeController,
            Route route)
        {
            //Information

            //Act
            routeController.Delete(route.RouteID);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

    }
}