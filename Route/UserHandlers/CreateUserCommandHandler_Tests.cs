namespace MCRoute.Test.UserHandlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using McWorld.User.Commands;
    using McWorld.User.Handler;
    using NUnit.Framework;

    public class CreateUserCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateUser_CallUserFactory(
            [Frozen] IUserFactory userFactory,
            CreateUserCommand message,
            User user,
            CreateUserCommandHandler createUserCommandHandler)
        {
            //Information
            A.CallTo(() => userFactory.Create(message.User)).Returns(user);

            //Act
            createUserCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => userFactory.Create(message.User)).MustHaveHappened();
        }


        [Test]
        [AutoCreateTestInput]
        public void CreateUser_CallIUserRepositoryAdd(
            [Frozen] IUserRepository userRepository,
            [Frozen] IUserFactory userFactory,
            CreateUserCommand message,
            User user,
            CreateUserCommandHandler createUserCommandHandler)
        {
            //Information
            A.CallTo(() => userFactory.Create(message.User)).Returns(user);

            //Act
            createUserCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => userRepository.Add(user)).MustHaveHappened();
        }
    }
}