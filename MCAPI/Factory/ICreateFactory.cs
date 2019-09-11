using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.Factory
{
    interface ICreateFactory<T> where T : class 
    {
        T Create(T message);
    }
}
