namespace Tests.MCRoute.Test
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
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



        [Test]
        [AutoCreateTestInput]
        public void CreateUser_withFactoryAndNewGuid()
        {
            //Information
            UserFactory userFactory = new UserFactory();
            User user = new User();
            var newUser = userFactory.Create(user);


            //Act

            //Test
            Assert.AreNotEqual(user.UserID, newUser.UserID);
        }

    }
}