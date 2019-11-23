namespace Tests.MCRoute.Test
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.User;
    using McWorld.User.Handler;
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
        public void CreateUser_SendICommandHandler(
            [Frozen] ICommandHandler<CreateUserCommand> commandHandler,
            User user,
            UserController userController
            )
        {
            //Information

            //Act
            userController.Create(user);

            //Test
            A.CallTo(() => commandHandler.ExecuteAsync(A<CreateUserCommand>.Ignored));
        }

                     
        [Test]
        [AutoCreateTestInput]
        public void CreateUser_CreateUserWithUserFactory(
            [Frozen] IUserFactory userFactory,
            CreateUserCommandHandler createUserCommandHandler,
            User user
            )
        {
            //Information

            //Act
            createUserCommandHandler.ExecuteAsync(new CreateUserCommand(user));

            //Test
            A.CallTo(() => userFactory.Create(user))
            .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateUser_AddToRepository(
            [Frozen] IUserRepository userRepository, 
            [Frozen] IUserFactory userFactory,
            CreateUserCommandHandler createUserCommandHandler,
            User user,
            UserController userController
           )
        {
            //Information
            A.CallTo(() => userFactory.Create(A<User>.Ignored)).Returns(user);

            //Act
            createUserCommandHandler.ExecuteAsync(new CreateUserCommand(user));

            //Test
            A.CallTo(() => userRepository.Add(user))
            .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void CreateUser_(
      [Frozen] IUserRepository userRepository,
      [Frozen] IUserFactory userFactory,
      CreateUserCommandHandler createUserCommandHandler,
      User user,
      UserController userController
     )
        {
            //Information
            A.CallTo(() => userFactory.Create(A<User>.Ignored)).Returns(user);

            //Act
            createUserCommandHandler.ExecuteAsync(new CreateUserCommand(user));

            //Test
            A.CallTo(() => userRepository.Add(user))
            .MustHaveHappenedOnceExactly();
        }

    }
}