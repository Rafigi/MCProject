namespace MCRoute.Test.Controllers
{
    using AutoFixture.NUnit3;
    using FakeItEasy;
    using global::MCRoute.Test;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using McWorld.Shared.Queryables;
    using McWorld.User;
    using McWorld.User.Commands;
    using McWorld.Web.Controllers;
    using NUnit.Framework;
    using System;

    public class UserController_Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        [AutoCreateTestInput]
        public void UserController_GetById(
            [Frozen] IUserQueryables userQueryables,
            UserController userController,
            Guid userId,
            UserDto userDto)
        {
            //Information
            A.CallTo(() => userQueryables.GetById(userId)).Returns(userDto);

            //Act
            userController.GetById(userId);

            //Test
            A.CallTo(() => userQueryables.GetById(userId))
                .MustHaveHappened();
        }


        [Test]
        [AutoCreateTestInput]
        public void UserController_Create_createUserCommandHandler(
            [Frozen] ICommandHandler<CreateUserCommand> createUserCommandHandler,
            [Frozen] IUserQueryables userQueryables,
            User user,
            UserController userController)
        {
            //Information
            A.CallTo(() => userQueryables.GetByUsername(A<string>.Ignored)).Returns(null);
            A.CallTo(() => userQueryables.GetByMail(A<string>.Ignored)).Returns(null);
            //Act
            userController.Create(user);

            //Test
            A.CallTo(() => createUserCommandHandler
            .ExecuteAsync(A<CreateUserCommand>.Ignored))
                .MustHaveHappened();

        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_Create_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            [Frozen] IUserQueryables userQueryables,
            User user,
            UserController userController)
        {
            //Information
            A.CallTo(() => userQueryables.GetByUsername(A<string>.Ignored)).Returns(null);
            A.CallTo(() => userQueryables.GetByMail(A<string>.Ignored)).Returns(null);

            //Act
            userController.Create(user);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_Create_WithAlreadyExistingEmail(
            [Frozen] IUnitOfWork unitOfWork,
            [Frozen] IUserQueryables userQueryables,
            UserDto userDto,
            User user,
            UserController userController)
        {
            //Information
            A.CallTo(() => userQueryables.GetByUsername(A<string>.Ignored)).Returns(userDto);
            A.CallTo(() => userQueryables.GetByMail(A<string>.Ignored)).Returns(null);

            //Act
            userController.Create(user);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustNotHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_Create_WithAlreadyExistingUsername(
            [Frozen] IUnitOfWork unitOfWork,
            [Frozen] IUserQueryables userQueryables,
            User user,
            UserDto userDto,
            UserController userController)
        {
            //Information
            A.CallTo(() => userQueryables.GetByUsername(A<string>.Ignored)).Returns(null);
            A.CallTo(() => userQueryables.GetByMail(A<string>.Ignored)).Returns(userDto);

            //Act
            userController.Create(user);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustNotHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_UpdateUser_UpdateUserCommandHandler(
            [Frozen] ICommandHandler<UpdateUserCommand> updateUserCommandHandler,
            User user,
            UserController userController)
        {
            //Information

            //Act
            userController.UpdateMail(user);

            //Test
            A.CallTo(() => updateUserCommandHandler
            .ExecuteAsync(A<UpdateUserCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_updateUser_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            User user,
            UserController userController)
        {
            //Information

            //Act
            userController.UpdateMail(user);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void UserController_UpdatePassword_UpdateUserCommandHandler(
            [Frozen] ICommandHandler<UpdatePasswordCommand> updatePasswordCommandHandler,
            User user,
            UserController userController)
        {
            //Information

            //Act
            userController.UpdatePassword(user);

            //Test
            A.CallTo(() => updatePasswordCommandHandler
            .ExecuteAsync(A<UpdatePasswordCommand>.Ignored))
            .MustHaveHappened();
        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_updatePassword_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            User user,
            UserController userController)
        {
            //Information

            //Act
            userController.UpdatePassword(user);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }


        [Test]
        [AutoCreateTestInput]
        public void UserController_Delete_deleteUserCommandHandler(
            [Frozen] ICommandHandler<DeleteUserCommand> deleteUserCommandHandler,
            UserController userController,
            User user)
        {
            //Information

            //Act
            userController.Delete(user.UserID);

            //Test
            A.CallTo(() => deleteUserCommandHandler
            .ExecuteAsync(A<DeleteUserCommand>.Ignored))
            .MustHaveHappened(); ;
        }

        [Test]
        [AutoCreateTestInput]
        public void UserController_Delete_IUnitOfWork(
            [Frozen] IUnitOfWork unitOfWork,
            UserController userController,
            User user)
        {
            //Information

            //Act
            userController.Delete(user.UserID);

            //Test
            A.CallTo(() => unitOfWork.Complete())
                .MustHaveHappenedOnceExactly();
        }

    }
}