namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using System;

    public interface IUserQueryables
    {
        /// <summary>
        /// Getting the User by Id.
        /// Return Null if Not Exists
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        UserDto GetById(Guid id);


        /// <summary>
        /// Getting the User by Mail.
        /// Return Null if Not Exists
        /// </summary>
        /// <param name="mail">The mail.</param>
        /// <returns></returns>
        UserDto GetByMail(string mail);


        /// <summary>
        /// Getting the Username if exist.
        /// Return Null if Not Exists
        /// </summary>
        /// <param name="username">The mail.</param>
        /// <returns></returns>
        UserDto GetByUsername(string username);
    }
}
