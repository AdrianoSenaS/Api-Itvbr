using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Itvbr.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Itvbr.Controllers
{
    [Route("api/series/[controller]")]
    public class Episodios : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<EpisodiosModel> Get()
        {
            return EpisodiosModel.GetEpisodios();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<EpisodiosModel> Get(int id)
        {
            return EpisodiosModel.GetEpisodiosId(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]EpisodiosModel value)
        {
            return EpisodiosModel.InsertEpisodios(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]EpisodiosModel value)
        {
            return EpisodiosModel.UpdateEpisodiosId(value, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return EpisodiosModel.DeleteEpisodiosId(id);
        }
    }
}

