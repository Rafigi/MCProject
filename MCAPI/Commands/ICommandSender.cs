using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Commands
{
    /// <summary>
    /// Defines a command sender.
    /// </summary>
    public interface ICommandSender
    {
        /// <summary>
        /// Send a command to a single command handler function.
        /// </summary>
        /// <typeparam name="T">Command type</typeparam>
        /// <param name="command">Command object to be sent</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>Task representing sending</returns>
        Task Send<T>(T command) where T : class, ICommand;
    }
}
