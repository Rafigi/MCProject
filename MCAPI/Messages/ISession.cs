using MCAPI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Messages
{
    /// <summary>
    /// Defines unit of work that handles several aggregates.
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Add aggregate to session
        /// </summary>
        /// <typeparam name="T">Type of aggregate</typeparam>
        /// <param name="aggregate">Aggregate object to be added</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task Add<T>(T command) where T : ICommand;

        /// <summary>
        /// Save changes in all aggregates in session
        /// </summary>
        /// <returns></returns>
        Task Commit();
    }
}
