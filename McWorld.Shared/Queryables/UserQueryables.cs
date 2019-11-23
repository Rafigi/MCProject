namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using McWorld.Shared.QueryStack;
    using System;
    using System.Linq;
    public class UserQueryables : IUserQueryables
    {
        private readonly QueryContext _queryContext;

        public UserQueryables(QueryContext queryContext)
        {
            _queryContext = queryContext;
        }

        public UserDto GetById(Guid id)
        {
            return _queryContext.Users.SingleOrDefault(i => i.UserId == id).AsDto();
        }

        public UserDto GetByMail(string mail)
        {
            return _queryContext.Users.SingleOrDefault(i => i.Email == mail).AsDto();
        }

        public UserDto GetByUsername(string username)
        {
            return _queryContext.Users.SingleOrDefault(i => i.Username == username).AsDto();
        }
    }
}
