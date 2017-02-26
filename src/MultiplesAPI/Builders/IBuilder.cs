using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public interface IBuilder<InputObject, OutputObject>
    {
        OutputObject Build(InputObject input);
    }
}
