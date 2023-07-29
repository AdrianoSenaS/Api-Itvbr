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
    public class Series : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<SeriesModel> Get()
        {
            return SeriesModel.GetSeries();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<SeriesModel> Get(int id)
        {
            return SeriesModel.GetSeriesId(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]SeriesModel value)
        {
            return SeriesModel.InsertSeries(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]SeriesModel value)
        {
            return SeriesModel.UpdateSeriesId(value, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return SeriesModel.DeleteSeriesId(id);
        }
    }
}

