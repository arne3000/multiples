using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Queries
{
    public interface IQuery<Input, Output>
    {
        Output Execute(Input value);
    }
}
