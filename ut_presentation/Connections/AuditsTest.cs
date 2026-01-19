using lib_domain.Entities;
using ut_presentation.Core;
using System.Collections.Generic;
using lib_application.Ports;
using lib_adapters.Adapters;

namespace ut_presentation.Connections
{
    [TestClass]
    public class AuditsTest
    {
        private readonly IConnection? iConnection;
        private List<Audits>? list;
        private Audits? entidad;

        public AuditsTest()
        {
            iConnection = new Connection();
            iConnection.StringConexion = Configuration.Get("StringConexion");
        }

        [TestMethod]
        public void Execute()
        {
            Assert.IsTrue(Insert());
        }

        public bool Insert()
        {
            this.entidad = EntitiesCore.Audits()!;
            this.iConnection!.Audits!.Add(this.entidad);
            this.iConnection!.SaveChanges();
            return true;
        }
    }
}