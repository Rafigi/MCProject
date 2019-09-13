using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Factory
{
    public interface IFactory<TType> where TType : class
    {
        TType Create(TType type);
        TType Update(TType type);
    }
}
