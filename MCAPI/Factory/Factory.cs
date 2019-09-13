using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Factory
{
    public class Factory : IFactory<Type>
    {
        public Type Create(Type type)
        {
            throw new NotImplementedException();
        }

        public Type Update(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
