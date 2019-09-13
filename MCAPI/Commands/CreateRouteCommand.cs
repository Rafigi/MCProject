﻿using MCAPI.Models;
using MCAPI.Persistence;
using System;
using System.Threading.Tasks;

namespace MCAPI.Commands
{
    public class CreateRouteCommand : ICommand
    {
        public Route Route { get; private set; }

        public CreateRouteCommand(Route route)
        {
            Route = new Route()
            {
                RouteID = route.RouteID,
                AddressID = route.AddressID,
                Created = route.Created,
                Distance = route.Distance,
                Ferry = route.Ferry,
                Motorway = route.Motorway,
                Toll = route.Toll,
                UserID = route.UserID
            };
        }

        public Task Execute(IUnitOfWork unitOfWork)
        {
            return Task.CompletedTask;
        }
    }
}
