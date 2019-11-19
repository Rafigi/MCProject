namespace Tests.MCRoute.Test
{
    using global::MCRoute.Test;
    using McWorld.Shared.Factory;
    using McWorld.Shared.Models;
    using NUnit.Framework;

    public class CreateUser_Test
    {
        [SetUp]
        public void Setup()
        {
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