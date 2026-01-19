using lib_domain.Entities;

namespace lib_application.Ports
{    
    public interface IAuditsRepository
    {
        void Configurar(string StringConexion);
        Audits Insert(Audits entity);
    }
}