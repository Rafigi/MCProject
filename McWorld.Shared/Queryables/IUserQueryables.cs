namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.QueryStack;
    using System;
    using System.Collections.Generic;
    public interface IUserQueryables
    {
        IEnumerable<Users> GetAll();
        Users GetById(Guid id);
        Users GetByMail(string mail);
    }
}
