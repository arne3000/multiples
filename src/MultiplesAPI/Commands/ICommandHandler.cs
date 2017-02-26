using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Commands
{
    public interface ICommandHandler<Command, Entity>
    {
        Entity Execute(Command command);
        ICommandHandler<Command, Entity> BindEntity(Entity entity);
    }
}
