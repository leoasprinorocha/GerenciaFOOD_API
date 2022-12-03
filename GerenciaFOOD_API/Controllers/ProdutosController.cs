using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaFOOD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {

            List<ProdutoMock> products = new List<ProdutoMock>();
            products.Add(new ProdutoMock() { Id = 1, Name = "Lanche" });
            products.Add(new ProdutoMock() { Id = 2, Name = "Suco" });
            products.Add(new ProdutoMock() { Id = 3, Name = "Pizza" });
            products.Add(new ProdutoMock() { Id = 4, Name = "Churros" });
            products.Add(new ProdutoMock() { Id = 5, Name = "Churros" });

            return Ok(products);


        }



    }



    public class ProdutoMock
    {

        public int Id { get; set; }

        public string Name { get; set; }

    }

}
