using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Itvbr.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Itvbr.Controllers
{
    [Route("api/[controller]")]
    public class Categorias : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<CategoriasModel> Get()
        {
            return  CategoriasModel.GetCategoriasModels();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<CategoriasModel> Get(int id)
        {
            return CategoriasModel.GetCategoriasModelsId(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]CategoriasModel categorias)
        {
            return CategoriasModel.InsertCategoriasModels(categorias);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]CategoriasModel categorias)
        {
            return CategoriasModel.UpdateCategoriasModels(categorias, id);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return CategoriasModel.DeleteCategoriasModels(id);
        }
    }
}

