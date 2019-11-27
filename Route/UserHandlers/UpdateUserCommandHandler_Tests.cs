namespace MCRoute.Test.UserHandlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using McWorld.User.Commands;
    using McWorld.User.Handler;
    using NUnit.Framework;
    using System.Collections.Generic;
    public class UpdateUserCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void UpdateUser_CallIUserRepositoryUpdate(
            [Frozen] IUserRepository userRepository,
            UpdateUserCommand message,
            User user,
            UpdateUserCommandHandler updateUserCommandHandler)
        {
            //Information
            A.CallTo(() => userRepository.GetById(message.UserId)).Returns(user);

            //Act
            updateUserCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => userRepository.Update(user)).MustHaveHappened();
        }
    }
}
