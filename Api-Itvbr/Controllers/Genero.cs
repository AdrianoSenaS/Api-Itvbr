using System;
using System.Collections.Generic;
using System.Linq;
using Api_Itvbr.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Itvbr.Controllers
{
    [Route("api/[controller]")]
    public class Genero : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<GeneroModel> Get()
        {
            return GeneroModel.GetGeneros();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<GeneroModel> Get(int id)
        {
            return GeneroModel.GetGenerosId(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]GeneroModel genero)
        {
            return GeneroModel.InsertGenero(genero);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]GeneroModel model)
        {
            return GeneroModel.UpdateGeneroId(model, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return GeneroModel.DeleteGeneroId(id);
        }
    }
}

