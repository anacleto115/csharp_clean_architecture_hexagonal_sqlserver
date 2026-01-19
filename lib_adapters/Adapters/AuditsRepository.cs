using lib_domain.Entities;
using System;
using lib_application.Ports;

namespace lib_adapters.Adapters
{
    public class AuditsRepository : IAuditsRepository
    {
        private IConnection? IConnection = null;

        public AuditsRepository(IConnection iConnection)
        {
            this.IConnection = iConnection;
        }

        public void Configurar(string StringConexion)
        {
            this.IConnection!.StringConexion = StringConexion;
        }

        public Audits Insert(Audits entity)
        {
            if (entity == null)
                throw new Exception("lbMissingInformation");

            if (entity.id != 0)
                throw new Exception("lbWasSaved");

            this.IConnection!.Audits!.Add(entity);
            this.IConnection!.SaveChanges();
            return entity;
        }
    }
}
