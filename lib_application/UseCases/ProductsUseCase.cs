using lib_application.Ports;
using lib_domain.Entities;
using System;
using System.Collections.Generic;

namespace lib_application.UseCases
{
    public class ProductsUseCase
    {
        private IProductsRepository IRepository;

        public ProductsUseCase(IConfiguration iConfiguration, IProductsRepository IRepository)
        {
            this.IRepository = IRepository;

            var stringConnection = iConfiguration.Get("db.string_conexion")!;
            this.IRepository!.Configurar(stringConnection);
        }

        public List<Products> Select()
        {
            // More Operations
            return this.IRepository!.Select();
        }

        public List<Products> Where(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            // More Operations
            return this.IRepository!.Where(entity);
        }

        public Products Insert(Products entity)
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

        public Products Update(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            // More Operations
            return this.IRepository!.Update(entity);
        }

        public Products Delete(Products entity)
        {
            if (Validate(entity))
                throw new Exception("lbMissingInformation");

            if (entity.id == 0)
                throw new Exception("lbWasNotSaved");

            // More Operations
            return this.IRepository!.Delete(entity);
        }

        private bool Validate(Products entity)
        {
            return entity == null ||
                string.IsNullOrEmpty(entity.name) ||
                entity.expire == null;
        }
    }
}