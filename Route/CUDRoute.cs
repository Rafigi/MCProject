namespace Tests.MCRoute.Test
{
    using McWorld.Route;
    using McWorld.Shared.Models;
    using McWorld.User;
    using NUnit.Framework;
    using System;
    public class CUDRoute
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateRoute()
        {
            var address = new Address
            {
                AddressID = Guid.NewGuid(),
                City = "Vejle",
                Country = "Denmark",
                Zipcode = 7100,
                StreetName = "Vejlevej",
                StreetNumber = "22",
                Latitude = "dewfwefweffwef",
                Longitude = "dqewdwefwefdew",
                Routes = null
            };

            var route = new Route
            {
                RouteID = Guid.NewGuid(),
                Address = address,
                AddressID = Guid.NewGuid(),
                Created = "11/09/19",
                Distance = 200,
                Events = null,
                Ferry = false,
                Motorway = false,
                Toll = false,
                User = null,
                UserID = Guid.NewGuid()
            };


            CreateRouteCommand createRouteCommand = new CreateRouteCommand(route);
            Assert.IsFalse(route.Ferry, "Ferry should be false");
            Assert.IsFalse(route.Motorway, "Motorway should be false");
            Assert.IsNotNull(route.Address, "Address should not be null");
            Assert.AreNotEqual(route, address, "Route and Address are not Equal");
            Assert.Positive(route.Distance, "Distance can be positive");
            Assert.NotZero(route.Distance, "Distance can not be 0");
        }

        [Test]
        public void CreateUser()
        {
            var user = new User
            {
                UserID = Guid.NewGuid(),
                Username = "Mads",
                Password = "123456wefrefwefec",
                Birthdate = "17/04/90",
                Created = "11/09/19",
                Email = "Mail@mail.dk",
                Events = null,
                Registration = null,
                Routes = null
            };

            CreateUserCommand createUserCommand = new CreateUserCommand(user);
            Assert.IsNotNull(user.UserID, "UserID cant be null");
            Assert.IsNotEmpty(user.Username, "Username can not be empty");
            Assert.IsNotEmpty(user.Password, "Password can not be empty");
            Assert.IsNotEmpty(user.Created, "Created can not be empty");
            Assert.IsNotEmpty(user.Birthdate, "Birthday can not be empty");
            Assert.IsNotEmpty(user.Email, "Email can not be empty");
        }
    }
}