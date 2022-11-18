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

            return Ok(products);


        }



    }



    public class ProdutoMock
    {

        public int Id { get; set; }

        public string Name { get; set; }

    }

}
