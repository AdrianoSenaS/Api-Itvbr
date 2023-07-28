using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Api_Itvbr.Model;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Itvbr.Controllers
{
    [Route("api/[controller]")]
    public class Filmes : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<ModelFilmes> Get()
        {
            return ModelFilmes.GetModelFilmes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<ModelFilmes> Get(int id)
        {
            return ModelFilmes.GetModelFilmesId(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]ModelFilmes filme)
        {
            return ModelFilmes.PostFilmes(filme);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]ModelFilmes filmes)
        {
            return ModelFilmes.UpdateModelFilmes(filmes, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return ModelFilmes.DeleteModelFilmes(id);
        }
    }
}

