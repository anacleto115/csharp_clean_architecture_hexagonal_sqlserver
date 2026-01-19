using lib_application.Ports;
using lib_domain.Entities;
using System;
using System.Collections.Generic;

namespace lib_application.UseCases
{
    public class TypesUseCase
    {
        private ITypesRepository IRepository;

        public TypesUseCase(IConfiguration iConfiguration, ITypesRepository IRepository)
        {
            this.IRepository = IRepository;

            var stringConnection = iConfiguration.Get("db.string_conexion")!;
            this.IRepository!.Configurar(stringConnection);
        }

        public List<Types> Select()
        {
            // More Operations
            return this.IRepository!.Select();
        }

        public List<Types> Where(Types entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            // More Operations
            return this.IRepository!.Where(entity);
        }

        public Types Insert(Types entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id != 0)
                throw new Exception("lbWasSaved");

            // More Operations
            entity = this.IRepository!.Insert(entity);

            if (entity.id == 0)
                throw new Exception("lbErrorInserting");
            return entity;
        }

        public Types Update(Types entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            // More Operations
            return this.IRepository!.Update(entity);
        }

        public Types Delete(Types entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            // More Operations
            return this.IRepository!.Delete(entity);
        }

        private bool Validate(Types entity)
        {
            return entity == null ||
                string.IsNullOrEmpty(entity.name);
        }
    }
}