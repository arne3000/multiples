using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Commands
{
    public abstract class BaseCommandHandler<Command, Entity> : ICommandHandler<Command, Entity>
    {
        private Entity TargetEntity;
        public Entity Execute(Command command)
        {
            var exception = Validate(command);

            if (exception != null)
            {
                throw exception;
            }

            if (TargetEntity == null)
            {
                TargetEntity = CreateNewEntity();
            }

            return Map(TargetEntity, command);
        }

        public ICommandHandler<Command, Entity> BindEntity(Entity entity)
        {
            TargetEntity = entity;
            return this;
        }

        protected abstract Exception Validate(Command command);
        protected abstract Entity Map(Entity entity, Command command);
        protected abstract Entity CreateNewEntity();
    }
}
