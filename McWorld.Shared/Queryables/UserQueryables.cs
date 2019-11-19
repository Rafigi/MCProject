namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.QueryStack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class UserQueryables :  IUserQueryables
    {
        private readonly QueryContext _queryContext;

        public UserQueryables(QueryContext queryContext)
        {
            _queryContext = queryContext;
        }


        public IEnumerable<Users> GetAll()
        {
            return _queryContext.Users;
        }

        public Users GetById(Guid id)
        {
            return _queryContext.Users.Single(i => i.UserId == id);
        }

        public Users GetByMail(string mail)
        {
            return _queryContext.Users.Single(i => i.Email == mail);
        }
    }
}
