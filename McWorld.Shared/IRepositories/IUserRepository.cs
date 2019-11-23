namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets the by id.
        /// Returning null if not Exists
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        User GetById(Guid id);
        /// <summary>
        /// Gets the by mail.
        /// Returning null if not Exists
        /// </summary>
        /// <param name="mail">The identifier.</param>
        /// <returns></returns>
        User GetByMail(string mail);
    }
}
