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
    using McWorld.User;
    using McWorld.Web.Controllers;
    using NUnit.Framework;

    public class CreateUser_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void Create_User_Factory(
            [Frozen] IUserFactory userFactory,
            User user)
        {
            //Information
            var _user = userFactory.Create(user);

            //Act
            A.CallTo(() => userFactory.Create(A<User>.Ignored)).Returns(user);

            //Test
            Assert.AreNotEqual(_user.UserID, user.UserID);
        }


        [Test]
        [AutoCreateTestInput]
        public void Send_User_With_ServiceBus(
          [Frozen] IUserFactory userFactory,
        [Frozen] IServiceBus serviceBus,
        UserController userController,
        User user
            )
        {
            //Information
            A.CallTo(() => userFactory.Create(A<User>.Ignored)).Returns(user);

            //Act
            userController.Create(user);

            //Test
            A.CallTo(() => serviceBus.Add(A<CreateUserCommand>.Ignored))
                .MustHaveHappened();
        }

    }
}