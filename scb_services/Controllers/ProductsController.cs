using lib_application.UseCases;
using lib_domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace scb_services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private ProductsUseCase? UseCase = null;

        public ProductsController(ProductsUseCase useCase)
        {
            this.UseCase = useCase;
        }

        [HttpGet]
        public List<Products> Select(Products entity)
        {
            return this.UseCase!.Select();
        }

        [HttpPost]
        public List<Products> Where(Products entity)
        {
            return this.UseCase!.Where(entity);
        }

        [HttpPost]
        public Products Insert(Products entity)
        {
            return this.UseCase!.Insert(entity);
        }

        [HttpPut]
        public Products Update(Products entity)
        {
            return this.UseCase!.Update(entity);
        }

        [HttpDelete]
        public Products Delete(Products entity)
        {
            return this.UseCase!.Delete(entity);
        }
    }
}