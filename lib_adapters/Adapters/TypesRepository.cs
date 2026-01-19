using lib_domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using lib_application.Ports;

namespace lib_adapters.Adapters
{
    public class TypesRepository : ITypesRepository
    {
        private IConnection? IConnection = null;
        private IAuditsRepository? IAuditsRepository = null;

        public TypesRepository(IConnection iConnection, IAuditsRepository iAuditsRepository)
        {
            this.IConnection = iConnection;
            this.IAuditsRepository = iAuditsRepository;
        }

        public void Configurar(string StringConexion)
        {
            this.IConnection!.StringConexion = StringConexion;
        }

        public List<Types> Select()
        {
            var list = this.IConnection!.Types!
                .Take(200)
                .ToList();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Types.Select", description = "" });
            return list;
        }

        public List<Types> Where(Types entity)
        {
            if (entity == null)
                throw new Exception("lbMissingInformation");

            var list = this.IConnection!.Types!
                .Where(x => x.name!.Contains(entity!.name!))
                .Take(200)
                .ToList();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Types.Where", description = entity.id.ToString() });
            return list;
        }

        public Types Insert(Types entity)
        {
            if (entity == null)
                throw new Exception("lbMissingInformation");

            this.IConnection!.Types!.Add(entity);
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Types.Insert", description = entity.id.ToString() });
            return entity;
        }

        public Types Update(Types entity)
        {
            if (entity == null)
                throw new Exception("lbMissingInformation");

            var entry = this.IConnection!.Entry<Types>(entity);
            entry.State = EntityState.Modified;
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Types.Update", description = entity.id.ToString() });
            return entity;
        }

        public Types Delete(Types entity)
        {
            if (entity == null)
                throw new Exception("lbMissingInformation");

            this.IConnection!.Types!.Remove(entity);
            this.IConnection!.SaveChanges();
            this.IAuditsRepository!.Insert(
                new Audits() { action = "Types.Delete", description = "" });
            return entity;
        }
    }
}