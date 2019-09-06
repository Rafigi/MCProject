using MCAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Messages
{
    public class Session : ISession
    {
        private List<ICommand> _commands = new List<ICommand>();
        public Task Add<T>(T command) where T : ICommand
        {
            _commands.Add(command);
            return Task.CompletedTask;
        }

        public Task Commit()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
            return Task.CompletedTask;
        }
    }
}
