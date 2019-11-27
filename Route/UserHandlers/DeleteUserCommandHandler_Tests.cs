namespace MCRoute.Test.UserHandlers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using McWorld.User.Commands;
    using McWorld.User.Handler;
    using NUnit.Framework;

    public class DeleteUserCommandHandler_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [AutoCreateTestInput]
        public void DeleteUser_CalluserRepositoryRemove(
            [Frozen] IUserRepository userRepository,
            DeleteUserCommand message,
            User user,
            DeleteUserCommandHandler deleteUserCommandHandler)
        {
            //Information
            A.CallTo(() => userRepository.GetById(message.UserId)).Returns(user);

            //Act
            deleteUserCommandHandler.ExecuteAsync(message);

            //Test
            A.CallTo(() => userRepository.Remove(user)).MustHaveHappened();
        }
    }
}
