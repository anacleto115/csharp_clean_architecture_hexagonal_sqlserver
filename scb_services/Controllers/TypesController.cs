using lib_application.UseCases;
using lib_domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace scb_services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TypesController : ControllerBase
    {
        private TypesUseCase? UseCase = null;

        public TypesController(TypesUseCase useCase)
        {
            this.UseCase = useCase;
        }

        [HttpGet]
        public List<Types> Select(Types entity)
        {
            return this.UseCase!.Select();
        }

        [HttpPost]
        public List<Types> Where(Types entity)
        {
            return this.UseCase!.Where(entity);
        }

        [HttpPost]
        public Types Insert(Types entity)
        {
            return this.UseCase!.Insert(entity);
        }

        [HttpPut]
        public Types Update(Types entity)
        {
            return this.UseCase!.Update(entity);
        }

        [HttpDelete]
        public Types Delete(Types entity)
        {
            return this.UseCase!.Delete(entity);
        }
    }
}